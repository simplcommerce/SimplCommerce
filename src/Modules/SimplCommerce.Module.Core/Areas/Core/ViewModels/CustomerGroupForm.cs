using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels
{
    public class CustomerGroupForm
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
