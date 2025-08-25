namespace BookClub.Common;

public class Result
{
    public bool Success { get; }
    public string? ErrorMessage { get; }
    public bool IsFailure => !Success;

    protected Result(bool success, string? errorMessage)
    {
        if (success && errorMessage != null)
            throw new InvalidOperationException();
        if (!success && errorMessage == null)
            throw new InvalidOperationException();
        Success = success;
        ErrorMessage = errorMessage;
    }

    public static Result Ok() => new(true, null);
    public static Result Fail(string message) => new(false, message);
}

public class Result<T> : Result
{
    public T? Value { get; }
    protected Result(bool success, T? value, string? errorMessage)
        : base(success, errorMessage)
    {
        Value = value;
    }
    public static Result<T> Ok(T value) => new(true, value, null);
    public static new Result<T> Fail(string errorMessage) => new(false, default, errorMessage);
}