using System.Collections.Generic;
using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class InstallmentInfo : IyzipayResource
    {
        public List<InstallmentDetail> InstallmentDetails { get; set; }

        public static InstallmentInfo Retrieve(RetrieveInstallmentInfoRequest request, Options options)
        {
            return RestHttpClient.Create().Post<InstallmentInfo>(options.BaseUrl + "/payment/iyzipos/installment",
                GetHttpHeaders(request, options), request);
        }
    }
}