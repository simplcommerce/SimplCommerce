namespace SimplCommerce.Module.ShoppingCart.ViewModels
{
    public class AddToCartModel
    {
        public long ProductId { get; set; }

        public string VariationName { get; set; }

        public int Quantity { get; set; }
    }
}
