using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.PaymentStripe.Areas.PaymentStripe.ViewModels
{
    public class StripeConfigForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string PublicKey { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string PrivateKey { get; set; }
    }
}
