using System.Data.Entity.ModelConfiguration;
using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.Infrastructure.EntityFramework.CustomMappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasOptional(x => x.CurrentShippingAddress).WithMany()
                .HasForeignKey(x => x.CurrentShippingAddressId)
                .WillCascadeOnDelete(false);
        }
    }
}