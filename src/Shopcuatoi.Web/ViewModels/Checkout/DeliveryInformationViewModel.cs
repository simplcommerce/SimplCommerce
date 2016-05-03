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

        public long ShippingAddressId { get; set; }

        public AddressFormViewModel NewAddressForm { get; set; }
    }
}