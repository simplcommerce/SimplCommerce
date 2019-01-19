using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentBraintree.Models;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentBraintree.Data
{
    public class PaymentBraintreeCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("Braintree") {
                    Name = PaymentProviderHelper.BraintreeProviderId,
                    LandingViewComponentName = "BraintreeLanding",
                    ConfigureUrl = "payments-braintree-config",
                    IsEnabled = true,
                    AdditionalSettings =
                    "{" +
                        "\"PublicKey\": \"6j4d7qspt5n48kx4\", " +
                        "\"PrivateKey\" : \"bd1c26e53a6d811243fcc3eb268113e1\", " +
                        "\"MerchantId\" : \"ncsh7wwqvzs3cx9q\", " +
                        "\"IsProduction\" : \"false\"" +
                    "}"
                }
            );
        }
    }
}
