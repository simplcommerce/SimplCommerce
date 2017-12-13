namespace SimplCommerce.Module.Payments.Services
{
    public class ProcessPaymentResponse
    {
        public string RedirectUrl { get; set; }

        public bool IsSuccess { get; set; }

        public string Error { get; set; }
    }
}
