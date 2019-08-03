namespace SimplCommerce.Module.PaymentCashfree.Areas.PaymentCashfree.ViewModels
{
    public class CashfreeCheckoutForm
    {
        public string AppId { get; set; }

        public string PaymentToken { get; set; }

        public string Mode { get; set; }

        public string OrderAmount { get; set; }

        public string OrderId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public string ReturnURL { get; set; }

        public string NotifyURL { get; set; }
    }
}
