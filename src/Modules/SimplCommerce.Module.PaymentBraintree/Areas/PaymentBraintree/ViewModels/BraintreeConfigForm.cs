using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplCommerce.Module.PaymentBraintree.Areas.PaymentBraintree.ViewModels
{
    public class BraintreeConfigForm
    {
        [Required]
        public string PublicKey { get; set; }

        [Required]
        public string PrivateKey { get; set; }

        [Required]
        public string MerchantId { get; set; }

        [Required]
        public bool IsProduction { get; set; } = false;

        [JsonIgnore]
        public string Environment { get { return IsProduction ? "production" : "sandbox"; } }
    }
}
