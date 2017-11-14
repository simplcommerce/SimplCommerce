namespace SimplCommerce.Module.Shipping.Services
{
    public class ShippingPrice
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PriceText
        {
            get
            {
               return Price.ToString("C");
            }
        }
    }
}
