using System.Runtime.Serialization;

namespace SimplCommerce.Module.PaymentStripeV2.Models
{
    //https://stripe.com/docs/payments/intents#intent-statuses

    public enum StripeIntentStatus
    {
        /// <summary>
        /// When the PaymentIntent is created, it has a status of requires_payment_method until a payment method is attached.
        /// </summary>
        [EnumMember(Value = "requires_payment_method")]
        RequiresPaymentMethod,

        /// <summary>
        /// After the customer provides their payment information, the PaymentIntent is ready to be confirmed.
        /// </summary>
        [EnumMember(Value = "requires_confirmation")]
        RequiresConfirmation,

        /// <summary>
        /// If the payment requires additional actions, such as authenticating with 3D Secure, the PaymentIntent has a status of requires_action.
        /// </summary>
        [EnumMember(Value = "requires_action")]
        RequiresAction,

        /// <summary>
        /// Once required actions are handled, the PaymentIntent moves to processing. While for some payment methods (e.g., cards) processing can be quick, other types of payment methods can take up to a few days to process.
        /// </summary>
        [EnumMember(Value = "processing")]
        Processing,

        /// <summary>
        /// You may cancel a PaymentIntent at any point before it is processing or succeeded. This invalidates the PaymentIntent for future payment attempts, and cannot be undone. If any funds have been held, cancellation returns those funds.
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled,

        /// <summary>
        /// A PaymentIntent with a status of succeeded means that the payment flow it is driving is complete.
        /// The funds are now in your account and you can confidently fulfill the order. If you need to refund the customer, you can use the Refunds API.
        /// </summary>
        [EnumMember(Value = "succeeded")]
        Succeeded,
    }
}
