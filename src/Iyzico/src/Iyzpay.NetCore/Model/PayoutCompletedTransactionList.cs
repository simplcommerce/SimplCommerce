using System.Collections.Generic;
using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class PayoutCompletedTransactionList : IyzipayResource
    {
        public List<PayoutCompletedTransaction> PayoutCompletedTransactions { get; set; }

        public static PayoutCompletedTransactionList Retrieve(RetrieveTransactionsRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PayoutCompletedTransactionList>(
                options.BaseUrl + "/reporting/settlement/payoutcompleted", GetHttpHeaders(request, options), request);
        }
    }
}