using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public string SeoTitle { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public long? ParentId { get; set; }

        public virtual Category Parent { get; set; }

        public virtual IList<Category> Child { get; protected set; } = new List<Category>();

        public string Image { get; set; }
    }
}