using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Core.Domain.Models
{
    public class ProductTemplateProductAttribute
    {
        public long TemplateId { get; set; }

        public ProductTemplate Template { get; set; }

        public long AttributeId { get; set; }

        public ProductAttribute Attribute { get; set; }
    }
}
