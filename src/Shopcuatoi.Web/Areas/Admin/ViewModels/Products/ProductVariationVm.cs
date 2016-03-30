using System.Collections.Generic;

namespace Shopcuatoi.Web.Areas.Admin.ViewModels.Products
{
    public class ProductVariationVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal? PriceOffset { get; set; }

        public IList<ProductAttributeCombinationVm> AttributeCombinations { get; set; } =
            new List<ProductAttributeCombinationVm>();
    }
}