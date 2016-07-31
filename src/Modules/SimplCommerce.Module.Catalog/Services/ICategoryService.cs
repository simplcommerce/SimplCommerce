using System.Collections.Generic;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface ICategoryService
    {
        IList<CategoryListItem> GetAll();

        void Create(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}
