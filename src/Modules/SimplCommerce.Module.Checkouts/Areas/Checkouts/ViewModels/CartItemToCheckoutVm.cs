namespace SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels
{
    public class CartItemToCheckoutVm
    {
        public long ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}
