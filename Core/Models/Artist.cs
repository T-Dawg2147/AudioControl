namespace AudioControl.Core.Models;

public sealed record Artist
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public IReadOnlyList<Album> Albums { get; init; } = Array.Empty<Album>();
}