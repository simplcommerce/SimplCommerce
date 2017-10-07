using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Contacts.Models
{
    public class ContactArea : EntityBase
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
