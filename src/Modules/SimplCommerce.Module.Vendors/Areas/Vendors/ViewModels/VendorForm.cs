using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Vendors.Areas.Vendors.ViewModels
{
    public class VendorForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Slug { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Email { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public IList<VendorManager> Managers { get; set; } = new List<VendorManager>();
     
    }
}
