namespace AudioControl.Core.Errors;

public record AudioError(ErrorCode Code, string Message, Exception? Exception = null)
{
    public override string ToString() => $"[{Code}] {Message}";
}