using System.Threading.Tasks;
using SimplCommerce.Module.News.Models;

namespace SimplCommerce.Module.News.Services
{
    public interface INewsItemService
    {
        void Create(NewsItem newsItem);

        void Update(NewsItem newsItem);

        Task Delete(long id);

        Task Delete(NewsItem newsItem);
    }
}
