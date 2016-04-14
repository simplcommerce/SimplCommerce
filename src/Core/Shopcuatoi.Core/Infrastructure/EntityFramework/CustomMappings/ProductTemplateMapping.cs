using System.Data.Entity.ModelConfiguration;
using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.Infrastructure.EntityFramework.CustomMappings
{
    public class ProductTemplateMapping : EntityTypeConfiguration<ProductTemplate>
    {
        public ProductTemplateMapping()
        {
            HasMany(p => p.ProductAttributes)
                .WithMany(t => t.ProductTemplates)
                .Map(mc => { mc.ToTable("Core_ProductTemplateProductAttribute"); });
        }
    }
}