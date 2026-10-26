using AudioControl.Core.Errors;
using AudioControl.Core.Events;
using AudioControl.Core.Models;

namespace AudioControl.Core.Abstraction;

public interface IAudioEngine : IDisposable
{
    PlaybackState State { get; }
    Track? CurrentTrack { get; }
    TimeSpan Position { get; }
    TimeSpan Duration { get; }
    
    float Volume { get; set; }
    bool IsMuted { get; set; }

    event EventHandler<PlaybackStateChangedEventArgs>? StateChanged;
    event EventHandler<PositionChangedEventArgs>? PositionChanged;
    event EventHandler<TrackEndedEventArgs>?  TrackEnded;
    event EventHandler<AudioErrorEventArgs>? ErrorOccurred;

    Task<Result> LoadAsync(Track track, CancellationToken ct = default);
    Result Play();
    Result Pause();
    Result Stop();
    Result Seek(TimeSpan position);

    Result SetOutputDevice(string? deviceId);
}