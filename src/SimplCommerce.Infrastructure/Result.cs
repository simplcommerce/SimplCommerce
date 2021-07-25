namespace SimplCommerce.Infrastructure
{
    public class Result
    {
        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public bool Success { get; }

        public string Error { get; }

        public static Result Fail(string error)
        {
            return new(false, error);
        }

        public static Result Ok()
        {
            return new(true, null);
        }

        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new(value, true, null);
        }

        public static Result<TValue> Fail<TValue>(string error)
        {
            return new(default, false, error);
        }
    }
}
