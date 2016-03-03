using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HvCommerce.Web.ViewModels.Catalog
{
    public class ProductDetailAttribute
    {
        public long AttributeId { get; set; }

        public string AttributeName { get; set; }

        public IList<string> Values { get; set; } = new List<string>();
    }
}
