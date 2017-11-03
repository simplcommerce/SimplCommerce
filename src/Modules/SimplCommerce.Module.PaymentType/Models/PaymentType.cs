
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.PaymentType.Models
{

    public class PaymentType : EntityBase
    {
        public string PaymentTypeName { get; set; }
        public string PaymentTypeDec { get; set; }
        public bool Confirmation { get; set; }
        public string Note { get; set; }
        public decimal Percent { get; set; }
        public decimal Min { get; set; }
        public int Code { get; set; }
        public Paymenttyp paymenttypep { get; set; }
    }

    public enum Paymenttyp
    {
        Paypal = 0  , Bank = 1   , Contrarembolso = 2
    }

    
}
