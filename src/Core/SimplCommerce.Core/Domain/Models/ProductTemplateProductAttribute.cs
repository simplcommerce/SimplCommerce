using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Core.Domain.Models
{
    public class ProductTemplateProductAttribute
    {
        public long ProductTemplateId { get; set; }

        public ProductTemplate ProductTemplate { get; set; }

        public long ProductAttributeId { get; set; }

        public ProductAttribute ProductAttribute { get; set; }
    }
}
