using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Contacts.Models
{
    public class ContactArea : EntityBase
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
