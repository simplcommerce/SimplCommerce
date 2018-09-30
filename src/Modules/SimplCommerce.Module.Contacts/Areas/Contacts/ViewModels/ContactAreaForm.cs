using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Contacts.ViewModels
{
    public class ContactAreaForm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
