using System.Collections.Generic;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Products
{
    public class ProductOptionVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IList<string> Values { get; set; } = new List<string>();
    }
}
