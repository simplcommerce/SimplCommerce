namespace SimplCommerce.Module.Shipping.ViewModels
{
    public class ShippingPriceRequestVm
    {
        public decimal OrderAmount { get; set; }

        public ShippingAddressVm NewShippingAddress { get; set; }

        public long ExistingShippingAddressId { get; set; }
    }
}
