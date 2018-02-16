using Iyzpay.NetCore.Request;
using Newtonsoft.Json;

namespace Iyzpay.NetCore.Model
{
    public class BinNumber : IyzipayResource
    {
        [JsonProperty(PropertyName = "binNumber")]
        public string Bin { get; set; }

        public string CardType { get; set; }
        public string CardAssociation { get; set; }
        public string CardFamily { get; set; }
        public string BankName { get; set; }
        public long BankCode { get; set; }

        public static BinNumber Retrieve(RetrieveBinNumberRequest request, Options options)
        {
            return RestHttpClient.Create().Post<BinNumber>(options.BaseUrl + "/payment/bin/check",
                GetHttpHeaders(request, options), request);
        }
    }
}