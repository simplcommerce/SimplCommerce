using System.Collections.Generic;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Localization.Models
{
    public class Culture : Entity
    {
        public string Name { get; set; }

        public IList<Resource> Resources { get; set; }
    }
}
