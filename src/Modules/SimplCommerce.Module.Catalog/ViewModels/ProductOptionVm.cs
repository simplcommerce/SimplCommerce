using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductOptionVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IList<string> Values { get; set; } = new List<string>();
    }
}
