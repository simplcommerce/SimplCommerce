namespace SimplCommerce.Module.Pricing.Services
{
    public class DiscountedProduct
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal DiscountAmount { get; set; }
    }
}
