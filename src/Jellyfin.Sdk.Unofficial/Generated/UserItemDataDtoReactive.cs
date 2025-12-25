using System.ComponentModel;

namespace Jellyfin.Sdk.Unofficial.Generated.Models;

/// <summary>
/// Documentation for the second part of UserItemDataDto.
/// </summary>
public partial class UserItemDataDto : INotifyPropertyChanged
{
    /// <summary>PropertyChanged.</summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>Gets or sets a value indicating whether Played.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public bool? ReactivePlayed
    {
        get => Played;
        set
        {
            Played = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactivePlayed)));
        }
    }
#nullable restore
#else
    public bool ReactivePlayed
    {
        get => Played ?? false;
        set
        {
            Played = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactivePlayed)));
        }
    }
#endif

    /// <summary>Gets or sets a value indicating whether IsFavorite.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public bool? ReactiveIsFavorite
    {
        get => IsFavorite;
        set
        {
            IsFavorite = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactiveIsFavorite)));
        }
    }
#nullable restore
#else
    public bool ReactiveIsFavorite
    {
        get => IsFavorite ?? false;
        set
        {
            IsFavorite = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReactiveIsFavorite)));
        }
    }
#endif

    /// <summary>Gets or sets a value indicating whether PlayedReactive.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public bool? PlayedReactive
    {
        get => Played;
        set
        {
            Played = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayedReactive)));
        }
    }
#nullable restore
#else
    public bool PlayedReactive
    {
        get => Played ?? false;
        set
        {
            Played = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayedReactive)));
        }
    }
#endif

    /// <summary>Gets or sets a value indicating whether IsFavorite.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public bool? IsFavoriteReactive
    {
        get => IsFavorite;
        set
        {
            IsFavorite = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFavoriteReactive)));
        }
    }
#nullable restore
#else
    public bool IsFavoriteReactive
    {
        get => IsFavorite ?? false;
        set
        {
            IsFavorite = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFavoriteReactive)));
        }
    }
#endif

    /// <summary>Gets or sets PlaybackPositionTicksReactive.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public long? PlaybackPositionTicksReactive
    {
        get => PlaybackPositionTicks;
        set
        {
            PlaybackPositionTicks = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlaybackPositionTicksReactive)));
        }
    }
#nullable restore
#else
    public long PlaybackPositionTicksReactive
    {
        get => PlaybackPositionTicks ?? 0;
        set
        {
            PlaybackPositionTicks = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlaybackPositionTicksReactive)));
        }
    }
#endif

    /// <summary>Gets or sets PlayedPercentageReactive.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
    public double? PlayedPercentageReactive
    {
        get => PlayedPercentage;
        set
        {
            PlayedPercentage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayedPercentageReactive)));
        }
    }
#nullable restore
#else
    public double PlayedPercentageReactive
    {
        get => PlayedPercentage ?? 0;
        set
        {
            PlayedPercentage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayedPercentageReactive)));
        }
    }
#endif

}
