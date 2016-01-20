using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public virtual Category Parent { get; set; }

        public virtual IList<Category> Child { get; protected set; }

        public string Image { get; set; }
    }
}