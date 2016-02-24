using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework;
using HvCommerce.Infrastructure.Domain.IRepositories;

namespace HvCommerce.Core.ApplicationServices
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Delete(long id)
        {
            var category = categoryRepository.Get(id);
            Delete(category);
        }

        public void Delete(Category category)
        {
            category.IsDeleted = true;

            foreach (var childCategory in category.Child)
            {
                Delete(childCategory);
            }
        }

        public async Task<bool> CheckExistBySeoTitle(string seoTitle)
        {
            using (this.categoryRepository = new Repository<Category>(new HvDbContext()))
            {
                return await categoryRepository.Query().AnyAsync(x => !x.IsDeleted && x.SeoTitle == seoTitle);
            }
        }
    }
}