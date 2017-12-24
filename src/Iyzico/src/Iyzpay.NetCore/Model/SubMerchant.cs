using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class SubMerchant : IyzipayResource
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string GsmNumber { get; set; }
        public string Address { get; set; }
        public string Iban { get; set; }
        public string SwiftCode { get; set; }
        public string Currency { get; set; }
        public string TaxOffice { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string LegalCompanyTitle { get; set; }
        public string SubMerchantExternalId { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxNumber { get; set; }
        public string SubMerchantType { get; set; }
        public string SubMerchantKey { get; set; }

        public static SubMerchant Create(CreateSubMerchantRequest request, Options options)
        {
            return RestHttpClient.Create().Post<SubMerchant>(options.BaseUrl + "/onboarding/submerchant",
                GetHttpHeaders(request, options), request);
        }

        public static SubMerchant Update(UpdateSubMerchantRequest request, Options options)
        {
            return RestHttpClient.Create().Put<SubMerchant>(options.BaseUrl + "/onboarding/submerchant",
                GetHttpHeaders(request, options), request);
        }

        public static SubMerchant Retrieve(RetrieveSubMerchantRequest request, Options options)
        {
            return RestHttpClient.Create().Post<SubMerchant>(options.BaseUrl + "/onboarding/submerchant/detail",
                GetHttpHeaders(request, options), request);
        }
    }
}