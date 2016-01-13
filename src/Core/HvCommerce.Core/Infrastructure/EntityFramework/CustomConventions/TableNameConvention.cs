using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Core.Infrastructure.EntityFramework.CustomConventions
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
            string[] nameParts = type.Namespace.Split('.');
            return string.Concat(nameParts[1], "_", type.Name);
        }
    }
}
