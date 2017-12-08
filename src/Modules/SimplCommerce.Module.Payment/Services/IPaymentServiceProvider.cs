using System.Threading.Tasks;

namespace SimplCommerce.Module.Payment.Services
{
    public interface IPaymentServiceProvider
    {
        Task<ProcessPaymentResult> ProcessPaymentPreOrder(ProcessPaymentRequest processPaymentRequest);

        Task<ProcessPaymentResult> ProcessPaymentPostOrder();
    }
}
