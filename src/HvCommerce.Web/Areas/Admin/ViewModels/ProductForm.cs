using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HvCommerce.Web.Areas.Admin.ViewModels
{
    public class ProductForm
    {
        public ProductForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public IList<long> CategoryIds { get; set; } = new List<long>();
    }
}