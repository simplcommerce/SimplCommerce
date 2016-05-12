using System.Collections.Generic;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Products
{
    public class ProductAttributeGroupVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IList<ProductAttributeVm> Attributes { get; set; } = new List<ProductAttributeVm>();
    }
}
