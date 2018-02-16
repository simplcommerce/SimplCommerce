using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class Card : IyzipayResource
    {
        public string ExternalId { get; set; }
        public string Email { get; set; }
        public string CardUserKey { get; set; }
        public string CardToken { get; set; }
        public string CardAlias { get; set; }
        public string BinNumber { get; set; }
        public string CardType { get; set; }
        public string CardAssociation { get; set; }
        public string CardFamily { get; set; }
        public long? CardBankCode { get; set; }
        public string CardBankName { get; set; }

        public static Card Create(CreateCardRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Card>(options.BaseUrl + "/cardstorage/card",
                GetHttpHeaders(request, options), request);
        }

        public static Card Delete(DeleteCardRequest request, Options options)
        {
            return RestHttpClient.Create().Delete<Card>(options.BaseUrl + "/cardstorage/card",
                GetHttpHeaders(request, options), request);
        }
    }
}