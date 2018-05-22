using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Data
{
    public class CoreCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().ToTable("Core_AppSetting");

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
                b.HasOne(ur => ur.Role).WithMany(x => x.Users).HasForeignKey(r => r.RoleId);
                b.HasOne(ur => ur.User).WithMany(x => x.Roles).HasForeignKey(u => u.UserId);
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

            modelBuilder.Entity<Entity>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.EntityId);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasOne(x => x.DefaultShippingAddress)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultShippingAddressId)
                   .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(x => x.DefaultBillingAddress)
                    .WithMany()
                    .HasForeignKey(x => x.DefaultBillingAddressId)
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

            modelBuilder.Entity<CustomerGroup>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<CustomerGroupUser>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.CustomerGroupId });
                b.HasOne(ur => ur.User).WithMany(r => r.CustomerGroups).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(ur => ur.CustomerGroup).WithMany(u => u.Users).HasForeignKey(u => u.CustomerGroupId).OnDelete(DeleteBehavior.Cascade);
                b.ToTable("Core_CustomerGroupUser");
            });

            CoreSeedData.SeedData(modelBuilder);
        }
    }
}
