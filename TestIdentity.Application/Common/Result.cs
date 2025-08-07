namespace TestIdentity.Application.Common;
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public string? Error { get; private set; }
    public T? Value { get; private set; }

    private Result(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Ok(T value) => new Result<T>(true, value, null);
    public static Result<T> Fail(string error) => new Result<T>(false, default, error);
}
