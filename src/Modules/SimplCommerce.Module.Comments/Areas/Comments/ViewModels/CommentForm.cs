using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Comments.Areas.Comments.ViewModels
{
    public class CommentForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string CommentText { get; set; }

        public string CommenterName { get; set; }

        public long? ParentId { get; set; }

        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }
    }
}
