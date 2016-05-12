using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using AspNet.Identity.EntityFramework6;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Core.Infrastructure.EntityFramework.CustomConventions;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Core.Infrastructure.EntityFramework
{
    public class HvDbContext : IdentityDbContext<User, Role,
        long, UserLogin, UserRole, UserClaim, RoleClaim>
    {
        public HvDbContext() : base(GlobalConfiguration.ConnectionString)
        {
        }

        public HvDbContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HvDbContext, AutomaticMigrationsConfiguration>());

            RegisterConventions(modelBuilder);

            List<Type> typeToRegisters = new List<Type>();
            foreach(var module in GlobalConfiguration.Modules)
            {
                typeToRegisters.AddRange(TypeLoader.FromAssemblies(Assembly.Load(module.AssemblyName)));
            }    

            RegisterCustomMapping(modelBuilder, typeToRegisters);

            RegisterEntities(modelBuilder, typeToRegisters);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new TableNameConvention());
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());
        }

        private void RegisterEntities(DbModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            var entityMethod = typeof (DbModelBuilder).GetMethod("Entity");

            var entityTypes = typeToRegisters.Where(x => x.IsSubclassOf(typeof (Entity)) && !x.IsAbstract);
            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
            }
        }

        private void RegisterCustomMapping(DbModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            var typesToRegister = typeToRegisters
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(
                    type =>
                        type.BaseType != null && type.BaseType.IsGenericType &&
                        type.BaseType.GetGenericTypeDefinition() == typeof (EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}