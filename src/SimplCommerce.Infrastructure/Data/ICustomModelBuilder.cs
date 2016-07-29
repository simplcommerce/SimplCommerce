using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
