namespace SimplCommerce.Module.Cms.ViewModels
{
    public class MenuItemForm
    {
        public long Id { get; set; }

        public long? ParentId { get; set; }

        public long? EntityId { get; set; }

        public string Name { get; set; }

        public string CustomLink { get; set; }
    }
}
