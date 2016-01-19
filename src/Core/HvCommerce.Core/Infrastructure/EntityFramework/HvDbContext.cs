using HvCommerce.Infrastructure.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework.CustomConventions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using HvCommerce.Infrastructure;
using AspNet.Identity.EntityFramework6;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.ApplicationServices;

namespace HvCommerce.Core.Infrastructure.EntityFramework
{
    public class HvDbContext : IdentityDbContext<User, Role,
        int, UserLogin, UserRole, UserClaim, RoleClaim>
    {
        public HvDbContext() : base(HvConnectionString.Value)
        {        
        }

        public HvDbContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HvDbContext, AutomaticMigrationsConfiguration>());

            RegisterConventions(modelBuilder);

            IEnumerable<Type> typeToRegisters = TypeLoader.FromAssemblies(new[] { Assembly.Load("HvCommerce.Core") });

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
            MethodInfo entityMethod = typeof(DbModelBuilder).GetMethod("Entity");

            IEnumerable<Type> entityTypes = typeToRegisters.Where(x => x.IsSubclassOf(typeof(Entity)) && !x.IsAbstract);
            foreach (Type type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
            }
        }

        private void RegisterCustomMapping(DbModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            IEnumerable<Type> typesToRegister = typeToRegisters
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(
                    type =>
                        type.BaseType != null && type.BaseType.IsGenericType &&
                        type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (Type type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}
