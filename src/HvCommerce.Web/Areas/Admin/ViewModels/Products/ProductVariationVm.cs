using System.Collections.Generic;

namespace HvCommerce.Web.Areas.Admin.ViewModels.Products
{
    public class ProductVariationVm
    {
        public string Name { get; set; }

        public decimal PriceOffset { get; set; }

        public IList<ProductAttributeCombinationVm> AttributeCombinations { get; set; } =
            new List<ProductAttributeCombinationVm>();
    }
}