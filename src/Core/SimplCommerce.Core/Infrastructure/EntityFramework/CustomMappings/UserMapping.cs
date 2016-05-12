using System.Data.Entity.ModelConfiguration;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.Infrastructure.EntityFramework.CustomMappings
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