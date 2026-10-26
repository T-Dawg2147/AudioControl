namespace AudioControl.Core.Models;

public sealed record Playlist
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public IReadOnlyList<string> TrackIds { get; init; } = Array.Empty<string>();
}