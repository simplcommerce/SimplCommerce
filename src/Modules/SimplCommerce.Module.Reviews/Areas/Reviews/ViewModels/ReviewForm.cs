using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels
{
    public class ReviewForm
    {
        [Range(1, 5)]
        public int Rating { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Comment { get; set; }

        public string ReviewerName { get; set; }

        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }

        public bool HasBoughtProduct { get; set; }

        public string LoggedUserName { get; set; }
    }
}
