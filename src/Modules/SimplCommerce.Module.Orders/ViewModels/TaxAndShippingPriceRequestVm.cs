namespace SimplCommerce.Module.Orders.ViewModels
{
    public class TaxAndShippingPriceRequestVm
    {
        public decimal OrderAmount { get; set; }

        public ShippingAddressVm NewShippingAddress { get; set; }

        public long ExistingShippingAddressId { get; set; }
    }
}
