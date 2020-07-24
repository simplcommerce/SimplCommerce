using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SimplCommerce.Module.Payments.Models;
using Stripe;
using Stripe.Checkout;

namespace SimplCommerce.Module.PaymentStripeV2.Services
{
    public interface IPaymentStripeV2Service
    {
        Task InitializeStripe();

        Task<object> CreateOrderForUser(long paymentAttemptId, string culture);

        Task<object> CreateOrderForUser(long paymentAttemptId);

        Task<object> CreateOrderForUser(Session session, PaymentIntent paymentIntent, PaymentAttempt paymentAttempt);

        Task<Session> GetSession(string sessionId);

        Task<PaymentIntent> GetPaymentIntent(string sessionId);

        Task<PaymentIntent> GetPaymentIntent(Session session);

        Task<PaymentAttempt> CreatePaymentAttempt(long cartId, decimal totalAmount, string message, [CallerMemberName] string callerMemberName = null);

        Task<PaymentAttempt> GetPaymentAttempt(long paymentAttemptId);

        Task UpdatePaymentAttempt();

        void LogSession(Session session, LogLevel logLevel = LogLevel.Debug);
    }
}
