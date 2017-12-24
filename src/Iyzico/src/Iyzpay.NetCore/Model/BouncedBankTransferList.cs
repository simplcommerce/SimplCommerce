using System.Collections.Generic;
using Iyzpay.NetCore.Request;
using Newtonsoft.Json;

namespace Iyzpay.NetCore.Model
{
    public class BouncedBankTransferList : IyzipayResource
    {
        [JsonProperty(PropertyName = "bouncedRows")]
        public List<BankTransfer> BankTransfers { get; set; }

        public static BouncedBankTransferList Retrieve(RetrieveTransactionsRequest request, Options options)
        {
            return RestHttpClient.Create().Post<BouncedBankTransferList>(
                options.BaseUrl + "/reporting/settlement/bounced", GetHttpHeaders(request, options), request);
        }
    }
}