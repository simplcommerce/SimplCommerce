namespace SimplCommerce.Infrastructure
{
    public class OkResult<T> : Result
    {
        public T Value { get; set; }

        protected internal OkResult(T value) : base(true, null)
        {
            Value = value;
        }
    }
}
