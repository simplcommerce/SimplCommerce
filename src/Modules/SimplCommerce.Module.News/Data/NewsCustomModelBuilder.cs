using SimplCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.News.Models;

namespace SimplCommerce.Module.News.Data
{
    public class NewsCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsItemCategory>(b =>
            {
                b.HasKey(ur => new { ur.CategoryId, ur.NewsItemId });
                b.HasOne(ur => ur.Category).WithMany(r => r.NewsItems).HasForeignKey(r => r.CategoryId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(ur => ur.NewsItem).WithMany(u => u.Categories).HasForeignKey(u => u.NewsItemId).OnDelete(DeleteBehavior.Cascade);
                b.ToTable("News_NewsItemCategory");
            });
        }
    }
}
