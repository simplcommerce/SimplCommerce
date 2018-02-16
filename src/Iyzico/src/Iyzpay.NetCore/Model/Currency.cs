namespace Iyzpay.NetCore.Model
{
    public sealed class Currency
    {
        public static readonly Currency TRY = new Currency("TRY");
        public static readonly Currency EUR = new Currency("EUR");
        public static readonly Currency USD = new Currency("USD");
        public static readonly Currency GBP = new Currency("GBP");
        public static readonly Currency IRR = new Currency("IRR");
        public static readonly Currency NOK = new Currency("NOK");
        public static readonly Currency RUB = new Currency("RUB");
        public static readonly Currency CHF = new Currency("CHF");
        private readonly string value;

        private Currency(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}