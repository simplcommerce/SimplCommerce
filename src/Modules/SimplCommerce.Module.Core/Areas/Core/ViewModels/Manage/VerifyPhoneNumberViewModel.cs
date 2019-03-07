using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels.Manage
{
    public class VerifyPhoneNumberViewModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
