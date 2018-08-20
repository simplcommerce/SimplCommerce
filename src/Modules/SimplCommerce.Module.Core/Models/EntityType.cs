using SimplCommerce.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Models
{
    public class EntityType : EntityBaseWithTypedId<string>
    {
        public EntityType()
        {

        }

        public EntityType(string id)
        {
            Id = id;
        }

        [Required]
        [StringLength(450)]
        public string Name { get { return Id; } }

        public bool IsMenuable { get; set; }

        public string RoutingController { get; set; }

        public string RoutingAction { get; set; }
    }
}
