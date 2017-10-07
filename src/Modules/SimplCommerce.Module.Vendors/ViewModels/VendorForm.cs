using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Vendors.ViewModels
{
    public class VendorForm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public IList<VendorManager> Managers { get; set; } = new List<VendorManager>();
     
    }
}
