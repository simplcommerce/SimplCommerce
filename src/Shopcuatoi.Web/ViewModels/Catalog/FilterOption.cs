using System.Collections.Generic;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class FilterOption
    {
        public IList<FilterBrand> Brands { get; set; } = new List<FilterBrand>();

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }
    }
}
