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

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get { return Id; } }

        public bool IsMenuable { get; set; }

        [StringLength(450)]
        public string AreaName { get; set; }

        [StringLength(450)]
        public string RoutingController { get; set; }

        [StringLength(450)]
        public string RoutingAction { get; set; }
    }
}
