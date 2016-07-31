using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class CategoryForm
    {
        public CategoryForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public long? ParentId { get; set; }

        public bool IsPublished { get; set; }
    }
}
