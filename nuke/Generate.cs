using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;

public partial class Generate : NukeBuild
{
    const string StableOpenApi = """
                                 "descriptionLocation": "https://raw.githubusercontent.com/linuxscreen/config/refs/heads/main/jellyfin-openapi-stable.json"
                                 """;
    
    const string UnstableOpenApi = """
                                 "descriptionLocation": "https://api.jellyfin.org/openapi/jellyfin-openapi-unstable.json"
                                 """;
    
    static readonly string[] _ignoreFiles =
    [
        ".editorconfig",
        "kiota-lock.json"
    ];
    
    public static int Main () => Execute<Generate>(x => x.Run);

    [Parameter("Configuration to build - 'Stable' (default) or 'Unstable'")]
    readonly Configuration Configuration = Configuration.Stable;
    
    [Solution(GenerateProjects = true)]
    readonly Solution Solution;

    Target RestoreTools => g => g.Executes(() => DotNetTasks.DotNetToolRestore());

    Target CleanGenerated => g => g.Executes(() =>
    {
        var generatedDirectory = new DirectoryInfo(Path.Combine(Solution.Jellyfin_Sdk_Unofficial.Directory, "Generated"));

        foreach (var file in generatedDirectory.GetFiles())
        {
            if (_ignoreFiles.Contains(file.Name, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            if (file.Name.EndsWith("Reactive.cs")) // 跳过 Reactive 相关文件, 改文件扩展了一些字段使得支持 Reactive 功能
            {
                continue;
            }

            file.Delete();
        }

        foreach (var directory in generatedDirectory.GetDirectories())
        {
            directory.Delete(recursive: true);
        }
    });
    
    Target UpdateConfig => g => g
        .DependsOn(RestoreTools, CleanGenerated)
        .Executes(() =>
        {
            var configPath = Path.Combine(Solution.Jellyfin_Sdk_Unofficial.Directory, "Generated", "kiota-lock.json");
            var config = File.ReadAllText(configPath);

            var desiredSpecification = Configuration == Configuration.Stable
                ? StableOpenApi
                : UnstableOpenApi;

            config = OpenApiRegex().Replace(config, desiredSpecification);
            File.WriteAllText(configPath, config);
        });

    Target Run => g => g
        .DependsOn(UpdateConfig)
        .Executes(() =>
        {
            DotNetTasks.DotNet(
                arguments: "kiota update --output Generated",
                workingDirectory: Solution.Jellyfin_Sdk_Unofficial.Directory);
            
            // TODO remove when Kiota 1.1.2 is released.
            var outputPath = Path.Combine(Solution.Jellyfin_Sdk_Unofficial.Directory, "Generated");
            foreach (var file in Directory.EnumerateFiles(outputPath, "*.cs", SearchOption.AllDirectories))
            {
                var contents = File.ReadAllText(file);
                contents = contents
                    .Replace(
                        "application/json;profile=\"CamelCase\"",
                        "application/json;profile=\\\"CamelCase\\\"")
                    .Replace(
                        "application/json;profile=\"PascalCase\"",
                        "application/json;profile=\\\"PascalCase\\\"");

                File.WriteAllText(file, contents);
            }
        });

    [GeneratedRegex("""
                    "descriptionLocation": ".+"
                    """)]
    private static partial Regex OpenApiRegex();
}
