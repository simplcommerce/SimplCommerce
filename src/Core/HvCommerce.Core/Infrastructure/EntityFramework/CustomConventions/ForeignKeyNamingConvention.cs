using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HvCommerce.Core.Infrastructure.EntityFramework.CustomConventions
{
    // Provides a convention for fixing the independent association (IA) foreign key column names.  
    public class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            // Identify ForeignKey properties (including IAs)  
            if (association.IsForeignKey)
            {
                // rename FK columns  
                var constraint = association.Constraint;
                if (DoPropertiesHaveDefaultNames(constraint.FromProperties, constraint.ToRole.Name, constraint.ToProperties))
                {
                    NormalizeForeignKeyProperties(constraint.FromProperties);
                }

                if (DoPropertiesHaveDefaultNames(constraint.ToProperties, constraint.FromRole.Name, constraint.FromProperties))
                {
                    NormalizeForeignKeyProperties(constraint.ToProperties);
                }
            }
        }

        private bool DoPropertiesHaveDefaultNames(ReadOnlyMetadataCollection<EdmProperty> properties, string roleName, ReadOnlyMetadataCollection<EdmProperty> otherEndProperties)
        {
            if (properties.Count != otherEndProperties.Count)
            {
                return false;
            }

            for (var i = 0; i < properties.Count; ++i)
            {
                if (!properties[i].Name.EndsWith("_" + otherEndProperties[i].Name))
                {
                    return false;
                }
            }

            return true;
        }

        private void NormalizeForeignKeyProperties(ReadOnlyMetadataCollection<EdmProperty> properties)
        {
            for (var i = 0; i < properties.Count; ++i)
            {
                var underscoreIndex = properties[i].Name.IndexOf('_');
                if (underscoreIndex > 0)
                {
                    properties[i].Name = properties[i].Name.Remove(underscoreIndex, 1);
                }
            }
        }
    }
}