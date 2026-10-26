namespace AudioControl.Core.Errors;

public enum ErrorCode
{
    Unknown = 0,
    FileNotFound,
    UnsupportedFormat,
    MetadataReadFailed,
    DeviceNotFound,
    DeviceFailure,
    PlaybackFailed,
    InvalidState,
    InvalidArgument,
    StorageFailure,
    NetworkFailure,
    AuthenticationFailed,
    Cancelled
}