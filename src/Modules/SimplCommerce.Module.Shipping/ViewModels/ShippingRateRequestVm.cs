namespace SimplCommerce.Module.Shipping.ViewModels
{
    public class ShippingRateRequestVm
    {
        public decimal OrderAmount { get; set; }

        public ShippingAddressVm ShippingAddress { get; set; }
    }
}
