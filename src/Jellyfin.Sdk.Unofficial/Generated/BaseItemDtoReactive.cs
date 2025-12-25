using System.ComponentModel;

namespace Jellyfin.Sdk.Unofficial.Generated.Models;

/// <summary>
/// Documentation for the second part of BaseItemDto.
/// </summary>
public partial class BaseItemDto : INotifyPropertyChanged
{
    /// <summary>PropertyChanged.</summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>Gets or sets the ReactiveName.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public string? ReactiveName
    {
        get => Name;
        set
        {
            Name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactiveName)));
        }
    }
#nullable restore
#else
    public string ReactiveName
    {
        get => Name ?? string.Empty;
        set
        {
            Name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactiveName)));
        }
    }
#endif

    /// <summary>Gets or sets the ReactiveUserData.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public UserItemDataDto? ReactiveUserData
    {
        get => UserData;
        set
        {
            UserData = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactiveUserData)));
        }
    }
#nullable restore
#else
    public UserItemDataDto ReactiveUserData
    {
        get => UserData ?? new();
        set
        {
            UserData = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactiveUserData)));
        }
    }
#endif
}
