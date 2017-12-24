namespace Iyzpay.NetCore.Request
{
    public class UpdateSubMerchantRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string GsmNumber { get; set; }
        public string Address { get; set; }
        public string Iban { get; set; }
        public string TaxOffice { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string LegalCompanyTitle { get; set; }
        public string SubMerchantKey { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxNumber { get; set; }
        public string Currency { get; set; }
        public string SwiftCode { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("name", Name)
                .Append("email", Email)
                .Append("gsmNumber", GsmNumber)
                .Append("address", Address)
                .Append("iban", Iban)
                .Append("taxOffice", TaxOffice)
                .Append("contactName", ContactName)
                .Append("contactSurname", ContactSurname)
                .Append("legalCompanyTitle", LegalCompanyTitle)
                .Append("swiftCode", SwiftCode)
                .Append("currency", Currency)
                .Append("subMerchantKey", SubMerchantKey)
                .Append("identityNumber", IdentityNumber)
                .Append("taxNumber", TaxNumber)
                .GetRequestString();
        }
    }
}