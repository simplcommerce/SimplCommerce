namespace SimplCommerce.Module.Shipping.ViewModels
{
    public class ShippingPriceRequestVm
    {
        public decimal OrderAmount { get; set; }

        public ShippingAddressVm ShippingAddress { get; set; }
    }
}
