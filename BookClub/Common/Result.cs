namespace BookClub.Common;

public class Result
{
    public bool Success { get; }
    public string? Message { get; }
    public bool Failed => !Success;

    protected Result(bool success, string? message)
    {
        if (!success && message == null)
            throw new InvalidOperationException();
        Success = success;
        Message = message;
    }

    public static Result Ok() => new(true, null);
    public static Result Ok(string message) => new(true, message);
    public static Result Fail(string message) => new(false, message);
}

public class Result<T> : Result
{
    public T? Value { get; }
    protected Result(bool success, T? value, string? message)
        : base(success, message)
    {
        Value = value;
    }
    public static Result<T> Ok(T value) => new(true, value, null);
    public static new Result<T> Fail(string errorMessage) => new(false, default, errorMessage);
}