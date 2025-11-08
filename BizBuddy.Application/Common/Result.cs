namespace BizBuddy.Application.Common;

public class Result
{
    internal Result(bool isSuccess, string message, string? exception = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Exception = exception;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string? Exception { get; set; }

    public static Result Success(string message = "Success") => new Result(true, message);
    public static Result Failure(string message = "Error", string? exception = null) => new Result(false, message, exception);
}

public class Result<T> : Result
{
    internal Result(T? data, bool isSuccess, string message, string? exception = null)
        : base(isSuccess, message, exception)
    {
        Data = data;
    }

    public T? Data { get; set; }

    public static Result<T> Success(T data, string message = "Success") => new Result<T>(data, true, message);
    public static Result<T> Failure(T? data, string message = "Error") => new Result<T>(data, false, message);
    public static Result<T> Failure(string message = "Error") => new Result<T>(default, false, message);
}
