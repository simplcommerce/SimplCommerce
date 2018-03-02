using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Pricing.Models;

namespace SimplCommerce.Module.Pricing.Data
{
    public class PricingCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>(b =>
            {
                b.HasOne(cc => cc.CartRule).WithMany(c => c.Coupons).HasForeignKey(x => x.CartRuleId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CartRuleCategory>(b =>
            {
                b.HasKey(cc => new { cc.CartRuleId, cc.CategoryId });
                b.HasOne(cc => cc.CartRule).WithMany(c => c.Categories).HasForeignKey(x => x.CartRuleId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(cc => cc.Category).WithMany().HasForeignKey(x => x.CategoryId);
            });

            modelBuilder.Entity<CartRuleProduct>(b =>
            {
                b.HasKey(cp => new { cp.CartRuleId, cp.ProductId });
                b.HasOne(cp => cp.CartRule).WithMany(p => p.Products).HasForeignKey(x => x.CartRuleId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(cp => cp.Product).WithMany().HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<CartRuleCustomerGroup>(b =>
            {
                b.HasKey(cc => new { cc.CartRuleId, cc.CustomerGroupId });
                b.HasOne(cc => cc.CartRule).WithMany(c => c.CustomerGroups).HasForeignKey(x => x.CartRuleId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(cc => cc.CustomerGroup).WithMany().HasForeignKey(x => x.CustomerGroupId);
            });

            modelBuilder.Entity<CatalogRuleCustomerGroup>(b =>
            {
                b.HasKey(cc => new { cc.CatalogRuleId, cc.CustomerGroupId });
                b.HasOne(cc => cc.CatalogRule).WithMany(c => c.CustomerGroups).HasForeignKey(x => x.CatalogRuleId);
                b.HasOne(cc => cc.CustomerGroup).WithMany().HasForeignKey(x => x.CustomerGroupId);
            });
        }
    }
}
