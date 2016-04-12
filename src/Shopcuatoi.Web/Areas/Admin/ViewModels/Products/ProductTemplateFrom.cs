using System.Collections.Generic;

namespace Shopcuatoi.Web.Areas.Admin.ViewModels.Products
{
    public class ProductTemplateFrom
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IList<ProductAttributeVm> Attributes { get; set; } = new List<ProductAttributeVm>();
    }
}
