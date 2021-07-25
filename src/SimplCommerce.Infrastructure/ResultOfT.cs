namespace SimplCommerce.Infrastructure
{
    public class Result<TValue> : Result
    {
        protected internal Result(TValue value, bool success, string error)
            : base(success, error)
        {
            Value = value;
        }

        public TValue Value { get; set; }
    }
}
