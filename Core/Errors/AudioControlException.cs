namespace AudioControl.Core.Errors;

public class AudioControlException : Exception
{
    public ErrorCode Code { get; }

    public AudioControlException(ErrorCode code, string message, Exception? exception = null) : base(message)
    {
        Code = code;
    }

    public AudioControlException(AudioError error)
        : this(error.Code, error.Message, error.Exception) { }

}