using System.Data.Entity.ModelConfiguration;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.Infrastructure.EntityFramework.CustomMappings
{
    public class AddressMapping : EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {
            HasRequired(d => d.District)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasRequired(d => d.StateOrProvince)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasRequired(d => d.Country)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}