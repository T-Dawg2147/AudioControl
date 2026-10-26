namespace AudioControl.Core.Errors;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public AudioError? Error { get; }

    protected Result(bool success, AudioError? error)
    {
        IsSuccess = success;
        Error = error;
    }

    public static Result Ok() => new(true, null);
    public static Result Fail(AudioError error) => new(false, error);
    public static Result Fail(ErrorCode code, string message, Exception? ex = null) => new(false, new AudioError(code, message, ex));

    public static Result<T> Ok<T>(T value) => Result<T>.Success(value);
    public static Result<T> Fail<T>(ErrorCode code, string message, Exception ex = null) => Result<T>.Failure(new AudioError(code, message, ex));
    public static Result<T> Fail<T>(AudioError error) => Result<T>.Failure(error);

    public static Result Try(Action action, ErrorCode code = ErrorCode.Unknown)
    {
        try
        {
            action();
            return Ok();
        }
        catch (AudioControlException ex) { return Fail(code, ex.Message, ex); }
        catch (OperationCanceledException ex) { return Fail(ErrorCode.Cancelled, "Operation cancelled.", ex); }
        catch (Exception ex) { return Fail(code, ex.Message, ex); }
    }

    public static Result<T> Try<T>(Func<T> func, ErrorCode code = ErrorCode.Unknown)
    {
        try
        {
            return Ok(func());
        }
        catch (AudioControlException ex) { return Fail<T>(ex.Code, ex.Message, ex); }
        catch (OperationCanceledException ex) { return Fail<T>(ErrorCode.Cancelled, "Operation cancelled.", ex); }
        catch (Exception ex) { return Fail<T>(code, ex.Message, ex); }
    }

    public static async Task<Result<T>> TryAsync<T>(Func<Task<T>> func, ErrorCode code = ErrorCode.Unknown)
    {
        try
        {
            return Ok(await func().ConfigureAwait(false));
        }
        catch (AudioControlException ex) { return Fail<T>(ex.Code, ex.Message, ex); }
        catch (OperationCanceledException ex) { return Fail<T>(ErrorCode.Cancelled, "Operation cancelled.", ex); }
        catch (Exception ex) { return Fail<T>(code, ex.Message, ex); }
    }
}

public sealed class Result<T> : Result
{
    private readonly T? _value;

    private Result(bool success, T? value, AudioError? error) : base(success, null)
    {
        _value = value;
    }

    /// <summary>
    /// Throws if the result is a failure. Check IsSuccess first
    /// </summary>
    public T Value => IsSuccess
        ? _value!
        : throw new AudioControlException(Error!);

    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(AudioError error) => new(false, default, error);

    public T? ValueOrDefault => _value;

    public bool TryGetValue(out T? value)
    {
        value = _value;
        return IsSuccess;
    }
}