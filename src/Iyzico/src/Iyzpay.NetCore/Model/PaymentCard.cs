namespace Iyzpay.NetCore.Model
{
    public class PaymentCard : IRequestStringConvertible
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
        public string Cvc { get; set; }
        public int? RegisterCard { get; set; }
        public string CardAlias { get; set; }
        public string CardToken { get; set; }
        public string CardUserKey { get; set; }

        public string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .Append("cardHolderName", CardHolderName)
                .Append("cardNumber", CardNumber)
                .Append("expireYear", ExpireYear)
                .Append("expireMonth", ExpireMonth)
                .Append("cvc", Cvc)
                .Append("registerCard", RegisterCard)
                .Append("cardAlias", CardAlias)
                .Append("cardToken", CardToken)
                .Append("cardUserKey", CardUserKey)
                .GetRequestString();
        }
    }
}