using System.Threading.Tasks;

namespace SimplCommerce.Module.Payments.Services
{
    public interface IPaymentServiceProvider
    {
        Task<ProcessPaymentResponse> ProcessPaymentPreOrder(ProcessPaymentRequest processPaymentRequest);

        Task<ProcessPaymentResponse> ProcessPaymentPostOrder();
    }
}
