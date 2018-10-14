using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
