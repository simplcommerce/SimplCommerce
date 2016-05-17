using System.ComponentModel.DataAnnotations;


namespace SimplCommerce.Web.Areas.Admin.ViewModels
{
    public class BrandForm
    {
        public BrandForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsPublished { get; set; }
    }
}
