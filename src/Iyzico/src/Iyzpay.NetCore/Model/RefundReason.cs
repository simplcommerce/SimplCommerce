namespace Iyzpay.NetCore.Model
{
    public sealed class RefundReason
    {
        public static readonly RefundReason DOUBLE_PAYMENT = new RefundReason("double_payment");
        public static readonly RefundReason BUYER_REQUEST = new RefundReason("buyer_request");
        public static readonly RefundReason FRAUD = new RefundReason("fraud");
        public static readonly RefundReason OTHER = new RefundReason("other");
        private readonly string value;

        private RefundReason(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}