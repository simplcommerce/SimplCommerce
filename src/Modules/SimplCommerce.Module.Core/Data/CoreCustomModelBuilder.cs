using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Data
{
    public class CoreCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Core_User");

            modelBuilder.Entity<Role>()
                .ToTable("Core_Role");

            modelBuilder.Entity<IdentityUserClaim<long>>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("Core_UserClaim");
            });

            modelBuilder.Entity<IdentityRoleClaim<long>>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("Core_RoleClaim");
            });

            modelBuilder.Entity<UserRole>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
                b.HasOne(ur => ur.Role).WithMany(r => r.Users).HasForeignKey(r => r.RoleId);
                b.HasOne(ur => ur.User).WithMany(u => u.Roles).HasForeignKey(u => u.UserId);
                b.ToTable("Core_UserRole");
            });

            modelBuilder.Entity<IdentityUserLogin<long>>(b =>
            {
                b.ToTable("Core_UserLogin");
            });

            modelBuilder.Entity<IdentityUserToken<long>>(b =>
            {
                b.ToTable("Core_UserToken");
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasOne(x => x.CurrentShippingAddress)
               .WithMany()
               .HasForeignKey(x => x.CurrentShippingAddressId)
               .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserAddress>()
                .HasOne(x => x.User)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>(x =>
            {
                x.HasOne(d => d.District)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(d => d.StateOrProvince)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(d => d.Country)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
