using TagLib.Matroska;

namespace AudioControl.Core.Models;

public sealed record Album
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public string Artist { get; init; } = "Unknown Artist";
    public string ArtistId { get; init; } = "Unknown Artist";
    public uint Year { get; init; }
    public SourceType Source { get; init; }
    public string? CoverArtPath { get; set; }
    public IReadOnlyList<TagLib.Matroska.Track> Tracks { get; init; } = Array.Empty<TagLib.Matroska.Track>();

    public TimeSpan TotalDuration => TimeSpan.FromTicks(Tracks.Sum(t => t.Duration.Ticks));
}