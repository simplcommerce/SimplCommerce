namespace SimplCommerce.Module.Orders.ViewModels
{
    public class TaxAndShippingPriceRequestVm
    {
        public string SelectedShippingMethodName { get; set; }

        public ShippingAddressVm NewShippingAddress { get; set; }

        public long ExistingShippingAddressId { get; set; }
    }
}
