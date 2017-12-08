using System.Threading.Tasks;

namespace SimplCommerce.Module.Payment.Services
{
    public interface IPaymentServiceProvider
    {
        Task<ProcessPaymentResponse> ProcessPaymentPreOrder(ProcessPaymentRequest processPaymentRequest);

        Task<ProcessPaymentResponse> ProcessPaymentPostOrder();
    }
}
