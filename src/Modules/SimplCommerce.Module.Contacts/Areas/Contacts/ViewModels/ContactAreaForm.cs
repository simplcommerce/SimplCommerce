using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Contacts.Areas.Contacts.ViewModels
{
    public class ContactAreaForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }
    }
}
