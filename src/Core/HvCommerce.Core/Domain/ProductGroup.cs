using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HvCommerce.Core.Domain.Models;

namespace HvCommerce.Core.Domain
{
    public class ProductGroup : Content
    {
        [StringLength(1000)]
        public string ShortDescription { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(5000)]
        public string Specification { get; set; }

        public int DisplayOrder { get; set; }

        public virtual IList<ProductMedia> Medias { get; set; }
    }
}
