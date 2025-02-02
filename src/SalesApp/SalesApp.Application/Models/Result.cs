namespace SalesApp.Application.Models
{
    public class Result<T>
    {
        public T? Content { get; protected set; }
        public bool IsSuccess { get; protected set; }
        public ResultError? Error { get; protected set; }

        public Result(T result)
        {
            Content = result;
            IsSuccess = true;
        }

        public Result(ResultError error)
        {
            Error = error;
            IsSuccess = false;
        }

        public static implicit operator Result<T>(T content)
        {
            return new Result<T>(content);
        }

        public static implicit operator Result<T>(ResultError error)
        {
            return new Result<T>(error);
        }
    }
}
