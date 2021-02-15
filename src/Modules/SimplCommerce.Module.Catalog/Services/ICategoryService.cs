using System.Threading.Tasks;
using System.Collections.Generic;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface ICategoryService
    {
        Task<IList<CategoryListItem>> GetAll();

        Task<Category> Create(CategoryForm model, string thumbnailImageName);

        Task Update(long id, CategoryForm model, string thumbnailImageName);

        Task Delete(Category category);
    }
}
