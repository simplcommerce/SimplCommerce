using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.WishList.Areas.WishList.ViewModels
{
    public class ShareWishListForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Message { get; set; }
    }
}
