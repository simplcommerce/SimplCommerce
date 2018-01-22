namespace SimplCommerce.Infrastructure
{
    public class Result
    {
        public bool Success { get; private set; }

        public string Error { get; private set; }

        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static OkResult<T> Ok<T>(T value)
        {
            return new OkResult<T>(value);
        }
    }
}
