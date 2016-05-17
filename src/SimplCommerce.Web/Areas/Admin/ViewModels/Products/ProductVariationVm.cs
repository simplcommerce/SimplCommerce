using System.Collections.Generic;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Products
{
    public class ProductVariationVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal PriceOffset { get; set; }

        public IList<ProductOptionCombinationVm> OptionCombinations { get; set; } =
            new List<ProductOptionCombinationVm>();
    }
}