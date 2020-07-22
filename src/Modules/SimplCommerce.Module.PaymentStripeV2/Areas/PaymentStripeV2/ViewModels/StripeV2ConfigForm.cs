using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.ViewModels
{
    public class StripeV2ConfigForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string PublicKey { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string PrivateKey { get; set; }
    }
}
