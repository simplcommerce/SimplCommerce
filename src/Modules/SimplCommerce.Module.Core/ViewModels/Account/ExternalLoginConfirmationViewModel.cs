using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }
    }
}
