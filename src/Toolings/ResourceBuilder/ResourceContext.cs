using System.Data.Entity;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;

namespace ResourceBuilder
{
    public class ResourceContext : DbContext
    {
        public ResourceContext() : base(GlobalConfiguration.ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StringResource>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Core_StringResource");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}