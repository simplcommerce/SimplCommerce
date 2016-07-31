using System;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductListItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool HasOptions { get; set; }

        public bool IsVisibleIndividually { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublished { get; set; }
    }
}
