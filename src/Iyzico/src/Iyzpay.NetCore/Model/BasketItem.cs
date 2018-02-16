namespace Iyzpay.NetCore.Model
{
    public class BasketItem : IRequestStringConvertible
    {
        public string Id { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string ItemType { get; set; }
        public string SubMerchantKey { get; set; }
        public string SubMerchantPrice { get; set; }

        public string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .Append("id", Id)
                .AppendPrice("price", Price)
                .Append("name", Name)
                .Append("category1", Category1)
                .Append("category2", Category2)
                .Append("itemType", ItemType)
                .Append("subMerchantKey", SubMerchantKey)
                .AppendPrice("subMerchantPrice", SubMerchantPrice)
                .GetRequestString();
        }
    }
}