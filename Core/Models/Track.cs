namespace AudioControl.Core.Models;

public sealed record Track
{
    public required string Id { get; init; }
    
    public required string Title { get; init; }
    public string Artist { get; init; } = "Unknown Artist";
    public string AlbumArtist { get; init; } = "Unknown Artist";
    public string Album { get; init; } = "Unknown Album";
    
    public string ArtistId { get; init; } = "Unknown Artist";
    public string AlbumId { get; init; } = "Unknown Album";
    
    public uint TrackNumber { get; init; }
    public uint DiscNumber { get; init; } = 1;
    public uint Year { get; init; }
    public string? Genre { get; init; }
    
    public TimeSpan Duration { get; init; }
    public AudioFormatInfo Format { get; init; } = AudioFormatInfo.Unknown;
    
    public SourceType Source { get; init; }
    
    public required string Url { get; init; }
    
    public string? CoverArtPath { get; init; }

}