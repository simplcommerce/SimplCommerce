using System.Collections.Generic;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class MenuForm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public IList<MenuItemForm> Items { get; set; } = new List<MenuItemForm>();
    }
}
