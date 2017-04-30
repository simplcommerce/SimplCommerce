namespace SimplCommerce.Module.RecentlyViewedProducts.Models
{
    public class RecentViewEntityDto
    {
        public long EntityId { get; set; }

        public long EntityTypeId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int ViewedCount { get; set; }
    }
}
