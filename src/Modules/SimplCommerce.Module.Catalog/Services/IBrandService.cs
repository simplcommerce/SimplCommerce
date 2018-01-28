using System.Threading.Tasks;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface IBrandService
    {
        Task Create(Brand brand);

        Task Update(Brand brand);

        Task Delete(long id);

        Task Delete(Brand brand);
    }
}
