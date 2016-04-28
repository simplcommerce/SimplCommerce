<<<<<<< HEAD
using System.Data.Entity;
=======
﻿using System.Data.Entity;
>>>>>>> d5de854... Update Localization functionality
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
            modelBuilder.Entity<Resource>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Core_Resource");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
