using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HvCommerce.Web.ViewModels.Catalog
{
    public class ProductDetailVariationAttribute
    {
        public long AttributeId { get; set; }

        public string AttributeName { get; set; }

        public string Value { get; set; }
    }
}
