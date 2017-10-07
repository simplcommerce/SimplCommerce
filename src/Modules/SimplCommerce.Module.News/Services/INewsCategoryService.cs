using System.Threading.Tasks;
using SimplCommerce.Module.News.Models;

namespace SimplCommerce.Module.News.Services
{
    public interface INewsCategoryService
    {
        void Create(NewsCategory category);

        void Update(NewsCategory category);

        Task Delete(long id);

        Task Delete(NewsCategory category);
    }
}
