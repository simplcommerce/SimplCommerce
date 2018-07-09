using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Reviews.ViewModels
{
    public class ReplyForm
    {
        [Required]
        public string Comment { get; set; }

        public string ReplierName { get; set; }

        public long ReviewId { get; set; }
    }
}
