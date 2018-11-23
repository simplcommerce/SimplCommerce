using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class DeliveryInformationVm
    {
        public DeliveryInformationVm()
        {
            NewAddressForm = new AddressFormVm();
        }

        public IList<ShippingAddressVm> ExistingShippingAddresses { get; set; } =
            new List<ShippingAddressVm>();

        public long ShippingAddressId { get; set; }

        public string ShippingMethod { get; set; }

        public AddressFormVm NewAddressForm { get; set; }

        public string OrderNote { get; set; }
    }
}
