using System.Collections.Generic;

namespace HvCommerce.Web.Areas.Admin.ViewModels.Products
{
    public class ProductAttributeVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IList<string> Values { get; set; } = new List<string>();
    }
}