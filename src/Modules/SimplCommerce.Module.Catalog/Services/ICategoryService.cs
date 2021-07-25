using System.Collections.Generic;
using System.Threading.Tasks;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface ICategoryService
    {
        Task<IList<CategoryListItem>> GetAll();

        Task Create(Category category);

        Task Update(Category category);

        Task Delete(Category category);
    }
}
