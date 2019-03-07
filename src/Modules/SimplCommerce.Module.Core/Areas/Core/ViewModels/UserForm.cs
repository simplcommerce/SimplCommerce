using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels
{
    public class UserForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string FullName { get; set; }

        public long? VendorId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public IList<long> RoleIds { get; set; } = new List<long>();
        public IList<long> CustomerGroupIds { get; set; } = new List<long>();
    }
}
