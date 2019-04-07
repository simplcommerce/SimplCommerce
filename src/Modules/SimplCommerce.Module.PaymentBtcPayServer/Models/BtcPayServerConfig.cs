using System;

namespace SimplCommerce.Module.PaymentBtcPayServer.Models
{
    public class BtcPayServerConfig
    {
        public Uri Server { get; set; }
        public string Seed { get; set; }
        public bool UseModal { get; set; } = true;
        public string PaymentButtonLabel { get; set; } = "Pay with Bitcoin";
    }
}
