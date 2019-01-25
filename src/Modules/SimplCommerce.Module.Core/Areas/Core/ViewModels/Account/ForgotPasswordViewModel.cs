using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
