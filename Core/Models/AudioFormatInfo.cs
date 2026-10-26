namespace AudioControl.Core.Models;

public sealed record AudioFormatInfo
{
    public string Coded { get; init; } = "Unknown";
    public int BitrateKbps { get; init; }
    public int SampleRate { get; init; }
    public int Channels { get; init; }
    public int BitsPerSample { get; init; }
    public TimeSpan Duration { get; init; }

    public static AudioFormatInfo Unknown => new();
}