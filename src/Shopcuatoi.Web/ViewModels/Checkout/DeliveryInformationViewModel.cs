using System.Collections.Generic;

namespace Shopcuatoi.Web.ViewModels.Checkout
{
    public class DeliveryInformationViewModel
    {
        public DeliveryInformationViewModel()
        {
            NewAddressForm = new AddressFormViewModel();
        }

        public IList<ShippingAddressViewModel> ExistingShippingAddresses { get; set; } =
            new List<ShippingAddressViewModel>();

        public AddressFormViewModel NewAddressForm { get; set; }
    }
}