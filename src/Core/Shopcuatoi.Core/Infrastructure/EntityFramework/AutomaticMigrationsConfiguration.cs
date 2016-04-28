using System.Data.Entity.Migrations;
using System.Linq;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.ServiceLocation;

namespace Shopcuatoi.Core.Infrastructure.EntityFramework
{
    public class AutomaticMigrationsConfiguration : DbMigrationsConfiguration<HvDbContext>
    {
        public AutomaticMigrationsConfiguration()
        {
            // During the initial development you can turn on this to speed up coding
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override async void Seed(HvDbContext context)
        {
            var roleManager = ServiceLocator.Current.GetInstance<RoleManager<Role>>();

            var adminRole = await roleManager.FindByNameAsync("admin");
            if (adminRole == null)
            {
                adminRole = new Role { Name = "admin" };
                await roleManager.CreateAsync(adminRole);

                var userManager = ServiceLocator.Current.GetInstance<UserManager<User>>();
                var adminUser = new User
                {
                    UserName = "admin@shopcuatoi.com",
                    Email = "admin@shopcuatoi.com",
                    FullName = "Shop Admin"
                };
                await userManager.CreateAsync(adminUser, "1qazZAQ!");
                await userManager.AddToRoleAsync(adminUser, adminRole.Name);

                var productAttrRepository = ServiceLocator.Current.GetInstance<IRepository<ProductOption>>();
                productAttrRepository.Add(new ProductOption { Name = "Color" });
                productAttrRepository.Add(new ProductOption { Name = "Size" });

                var sqlRepository = ServiceLocator.Current.GetInstance<ISqlRepository>();
                sqlRepository.CreateInitData();

                productAttrRepository.SaveChange();
            }

            base.Seed(context);
        }
    }
}