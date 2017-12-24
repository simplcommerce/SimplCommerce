using System.Collections.Generic;
using Iyzpay.NetCore.Model;

namespace Iyzpay.NetCore.Request
{
    public class CreateApmInitializeRequest : BaseRequest
    {
        public string Price { get; set; }
        public string PaidPrice { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentGroup { get; set; }
        public string PaymentSource { get; set; }
        public string Currency { get; set; }
        public string BasketId { get; set; }
        public string MerchantOrderId { get; set; }
        public string CountryCode { get; set; }
        public string AccountHolderName { get; set; }
        public string MerchantCallbackUrl { get; set; }
        public string MerchantErrorUrl { get; set; }
        public string MerchantNotificationUrl { get; set; }
        public string ApmType { get; set; }
        public Buyer Buyer { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .AppendPrice("price", Price)
                .AppendPrice("paidPrice", PaidPrice)
                .Append("paymentChannel", PaymentChannel)
                .Append("paymentGroup", PaymentGroup)
                .Append("paymentSource", PaymentSource)
                .Append("currency", Currency)
                .Append("merchantOrderId", MerchantOrderId)
                .Append("countryCode", CountryCode)
                .Append("accountHolderName", AccountHolderName)
                .Append("merchantCallbackUrl", MerchantCallbackUrl)
                .Append("merchantErrorUrl", MerchantErrorUrl)
                .Append("merchantNotificationUrl", MerchantNotificationUrl)
                .Append("apmType", ApmType)
                .Append("basketId", BasketId)
                .Append("buyer", Buyer)
                .Append("shippingAddress", ShippingAddress)
                .Append("billingAddress", BillingAddress)
                .AppendList("basketItems", BasketItems)
                .GetRequestString();
        }
    }
}