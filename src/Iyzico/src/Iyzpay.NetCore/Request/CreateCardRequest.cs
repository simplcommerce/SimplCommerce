using Iyzpay.NetCore.Model;

namespace Iyzpay.NetCore.Request
{
    public class CreateCardRequest : BaseRequest
    {
        public string ExternalId { get; set; }
        public string Email { get; set; }
        public string CardUserKey { get; set; }
        public CardInformation Card { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("externalId", ExternalId)
                .Append("email", Email)
                .Append("cardUserKey", CardUserKey)
                .Append("card", Card)
                .GetRequestString();
        }
    }
}