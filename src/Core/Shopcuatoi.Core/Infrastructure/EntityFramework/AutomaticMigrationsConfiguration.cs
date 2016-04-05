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
            var userManager = ServiceLocator.Current.GetInstance<UserManager<User>>();
            var roleManager = ServiceLocator.Current.GetInstance<RoleManager<Role>>();

            var adminRole = await roleManager.FindByNameAsync("admin");
            if (adminRole == null)
            {
                adminRole = new Role { Name = "admin" };
                await roleManager.CreateAsync(adminRole);
            }

            var adminUser = await userManager.FindByNameAsync("admin@shopcuatoi.com");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin@shopcuatoi.com",
                    Email = "admin@shopcuatoi.com",
                    FullName = "Shop Admin"
                };
                await userManager.CreateAsync(adminUser, "1qazZAQ!");
                await userManager.AddToRoleAsync(adminUser, adminRole.Name);
            }

            var productAttrRepository = ServiceLocator.Current.GetInstance<IRepository<ProductAttribute>>();
            if (productAttrRepository.Query().FirstOrDefault(x => x.Name == "Color") == null)
            {
                productAttrRepository.Add(new ProductAttribute { Name = "Color" });
            }

            if (productAttrRepository.Query().FirstOrDefault(x => x.Name == "Size") == null)
            {
                productAttrRepository.Add(new ProductAttribute { Name = "Size" });
            }

            productAttrRepository.SaveChange();

            base.Seed(context);
        }
    }
}