using SimplCommerce.Infrastructure.Models;
using System.Collections.Generic;

namespace SimplCommerce.Module.Cms.Models
{
    public class Menu : EntityBase
    {
        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public bool IsSystem { get; set; }

        public IList<MenuItem> MenuItems { get; protected set; } = new List<MenuItem>();
    }
}
