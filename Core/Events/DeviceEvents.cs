namespace AudioControl.Core.Events;

public enum DeviceChangeKind
{
    Added,
    Removed,
    DefaultChanged,
    StateChanged
}

public sealed class DeviceChangedEventArgs : EventArgs
{
    public DeviceChangeKind Kind { get; }
    public string DeviceId { get; }

    public DeviceChangedEventArgs(DeviceChangeKind kind, string deviceId)
    {
        Kind = kind;
        DeviceId = deviceId;
    }
}