using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.ShoppingCart.Models;

namespace SimplCommerce.Module.Payments.Models
{
    public class PaymentAttempt : EntityBase
    {
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset LatestUpdatedOn { get; set; } = DateTimeOffset.Now;

        public long CartId { get; set; }

        public Cart Cart { get; set; }

        public string PaymentProviderId { get; set; }

        public PaymentProvider PaymentProvider { get; set; }

        public string PaymentAttemptId { get; set; }

        public string Environment { get; set; } = System. Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public decimal RequestedAmount { get; set; }

        public string AdditionalInformation { get; set; }

        public bool IsProcessed { get; set; }

        public void UpdatedNow()
        {
            LatestUpdatedOn = DateTimeOffset.Now;
        }
    }
}
