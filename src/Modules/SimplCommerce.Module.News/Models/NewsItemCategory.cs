namespace SimplCommerce.Module.News.Models
{
    public class NewsItemCategory
    {
        public long CategoryId { get; set; }

        public long NewsItemId { get; set; }

        public NewsCategory Category { get; set; }

        public NewsItem NewsItem { get; set; }
    }
}
