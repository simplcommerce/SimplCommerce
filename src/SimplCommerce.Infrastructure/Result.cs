namespace SimplCommerce.Infrastructure
{
    public class Result
    {
        public bool Success { get; }

        public string Error { get; }

        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string error)
        {
            return new Result(false, error);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, null);
        }

        public static Result<TValue> Fail<TValue>(string error)
        {
            return new Result<TValue>(default(TValue), false, error);
        }
    }
}
