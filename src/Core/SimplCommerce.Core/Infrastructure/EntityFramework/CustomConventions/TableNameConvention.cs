using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimplCommerce.Core.Infrastructure.EntityFramework.CustomConventions
{
    public class TableNameConvention : Convention
    {
        public TableNameConvention()
        {
            Types().Configure(c => c.ToTable(GetTableName(c.ClrType)));
        }

        private static string GetTableName(Type type)
        {
            // Name of table is ModuleName_ClassName
            var nameParts = type.Namespace.Split('.');
            return string.Concat(nameParts[1], "_", type.Name);
        }
    }
}