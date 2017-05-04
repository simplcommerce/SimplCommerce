namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class CategoryListItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IncludeInMenu { get; set; }

        public bool IsPublished { get; set; }
    }
}
