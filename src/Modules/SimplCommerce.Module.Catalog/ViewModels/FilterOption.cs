using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class FilterOption
    {
        public IList<FilterBrand> Brands { get; set; } = new List<FilterBrand>();

        public FilterPrice Price { get; set; } = new FilterPrice();
    }
}
