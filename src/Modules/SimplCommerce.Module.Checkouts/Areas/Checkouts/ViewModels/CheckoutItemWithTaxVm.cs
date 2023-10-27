using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels
{
    public class CheckoutItemWithTaxVm
    {
        public int Quantity;

        public decimal Price;

        public long? TaxClassId;
    }
}
