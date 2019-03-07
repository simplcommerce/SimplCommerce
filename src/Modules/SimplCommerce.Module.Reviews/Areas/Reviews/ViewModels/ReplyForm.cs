using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels
{
    public class ReplyForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Comment { get; set; }

        public string ReplierName { get; set; }

        public long ReviewId { get; set; }
    }
}
