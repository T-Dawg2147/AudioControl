using AudioControl.Core.Errors;
using AudioControl.Core.Models;
using TagLib.Matroska;
using Track = TagLib.Matroska.Track;

namespace AudioControl.Core.Events;

public sealed class TrackChangedEventArgs : EventArgs
{
    public Track? Previous { get; }
    public Track? Current { get; }

    public TrackChangedEventArgs(Track? previous, Track? current)
    {
        Previous = previous;
        Current = current;
    }
}

public sealed class PlaybackStateChangedEventArgs : EventArgs
{
    public PlaybackState? OldState { get; }
    public PlaybackState? NewState { get; }

    public PlaybackStateChangedEventArgs(PlaybackState? oldState, PlaybackState? newState)
    {
        OldState = oldState;
        NewState = newState;
    }
}

public sealed class PositionChangedEventArgs : EventArgs
{
    public TimeSpan? Position { get; }
    public TimeSpan? Duration { get; }
    
    public PositionChangedEventArgs(TimeSpan? position, TimeSpan? duration)
    {
        Position = position;
        Duration = duration;
    }
}

public sealed class AudioErrorEventArgs : EventArgs
{
    public AudioError Error { get; }
    public AudioErrorEventArgs(AudioError error) => Error = error;
}

public sealed class TrackEndedEventArgs : EventArgs
{
    public Track? Track { get; }
    public TrackEndedEventArgs(Track? track) => Track = track;
}