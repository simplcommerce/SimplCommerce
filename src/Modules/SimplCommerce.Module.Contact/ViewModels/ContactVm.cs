using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimplCommerce.Module.Contact.ViewModels
{
    public class ContactVm
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        public string Address { get; set; }

        public string Content { get; set; }

        public long CategoryId { get; set; }

        public IList<ContactCategoryVm> Categories { get; set; } = new List<ContactCategoryVm>();

        public CompanyInformation Company { get; set; }
    }
}
