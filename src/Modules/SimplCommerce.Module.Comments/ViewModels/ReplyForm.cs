using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Comments.ViewModels
{
    public class ReplyForm
    {
        [Required]
        public string Comment { get; set; }

        public string ReplierName { get; set; }

        public long CommentId { get; set; }
    }
}
