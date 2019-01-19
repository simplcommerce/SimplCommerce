using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Contacts.Areas.Contacts.ViewModels
{
    public class ContactVm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Address { get; set; }

        public string Content { get; set; }

        public long ContactAreaId { get; set; }

        public IList<ContactAreaVm> ContactAreas { get; set; } = new List<ContactAreaVm>();

        public CompanyInformation Company { get; set; }
    }
}
