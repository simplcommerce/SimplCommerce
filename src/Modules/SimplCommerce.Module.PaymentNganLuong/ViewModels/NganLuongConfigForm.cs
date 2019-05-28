namespace SimplCommerce.Module.PaymentNganLuong.ViewModels
{
    public class NganLuongConfigForm
    {
        public int MerchantId { get; set; }

        public string MerchantPassword { get; set; }

        public string ReceiverEmail { get; set; }

        public bool IsSandbox { get; set; }
    }
}
