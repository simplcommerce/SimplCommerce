using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductOption : EntityBase
    {
        public ProductOption()
        {

        }

        public ProductOption(long id)
        {
            Id = id;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }
    }
}
