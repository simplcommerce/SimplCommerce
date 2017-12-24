namespace Iyzpay.NetCore.Model
{
    public sealed class Locale
    {
        public static readonly Locale EN = new Locale("en");
        public static readonly Locale TR = new Locale("tr");
        private readonly string value;

        private Locale(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}