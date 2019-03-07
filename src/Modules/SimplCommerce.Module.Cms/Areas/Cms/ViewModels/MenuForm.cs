using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Cms.Areas.Cms.ViewModels
{
    public class MenuForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public IList<MenuItemForm> Items { get; set; } = new List<MenuItemForm>();
    }
}
