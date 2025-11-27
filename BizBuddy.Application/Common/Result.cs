namespace BizBuddy.Application.Common;

public class Result
{
    public bool IsSuccess { get; init; }
    public string Message { get; init; } = string.Empty;
    public string? Exception { get; init; }

    protected Result(bool isSuccess, string message, string? exception = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Exception = exception;
    }

    public static Result Success(string message = "Success")
        => new Result(true, message);

    public static Result Failure(string message = "Error", string? exception = null)
        => new Result(false, message, exception);
}

public class Result<T> : Result
{
    public T? Data { get; init; }

    private Result(T? data, bool isSuccess, string message, string? exception = null)
        : base(isSuccess, message, exception)
    {
        Data = data;
    }

    public static Result<T> Success(T data, string message = "Success")
        => new Result<T>(data, true, message);

    public static Result<T> Failure(string message = "Error", string? exception = null)
        => new Result<T>(default, false, message, exception);

    public static Result<T> Failure(T? data, string message = "Error", string? exception = null)
        => new Result<T>(data, false, message, exception);
}
