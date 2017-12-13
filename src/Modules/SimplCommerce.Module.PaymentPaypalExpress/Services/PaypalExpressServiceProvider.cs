using System.Threading.Tasks;
using SimplCommerce.Module.Payments.Services;

namespace SimplCommerce.Module.PaymentPaypalExpress.Services
{
    public class PaypalExpressServiceProvider : IPaymentServiceProvider
    {
        public Task<ProcessPaymentResponse> ProcessPaymentPreOrder(ProcessPaymentRequest processPaymentRequest)
        {
            return Task.FromResult(new ProcessPaymentResponse());
        }

        public Task<ProcessPaymentResponse> ProcessPaymentPostOrder()
        {
            return Task.FromResult(new ProcessPaymentResponse());
        }
    }
}
