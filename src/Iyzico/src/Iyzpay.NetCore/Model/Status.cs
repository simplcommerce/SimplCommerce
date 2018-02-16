namespace Iyzpay.NetCore.Model
{
    public sealed class Status
    {
        public static readonly Status SUCCESS = new Status("success");
        public static readonly Status FAILURE = new Status("failure");
        private readonly string value;

        private Status(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}