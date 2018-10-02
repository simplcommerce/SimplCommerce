using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class CategoriesTree
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int Count { get; set; }

        public IList<CategoriesTree> ChildCategories { get; set; } = new List<CategoriesTree>();
    }
}
