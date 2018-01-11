using System.Threading.Tasks;
using SimplCommerce.Module.News.Models;

namespace SimplCommerce.Module.News.Services
{
    public interface INewsCategoryService
    {
        Task Create(NewsCategory category);

        Task Update(NewsCategory category);

        Task Delete(long id);

        Task Delete(NewsCategory category);
    }
}
