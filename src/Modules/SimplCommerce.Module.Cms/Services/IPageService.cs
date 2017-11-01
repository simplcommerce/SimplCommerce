using System.Threading.Tasks;
using SimplCommerce.Module.Cms.Models;

namespace SimplCommerce.Module.Cms.Services
{
    public interface IPageService
    {
        Task Create(Page page);

        Task Update(Page page);

        Task Delete(Page page);
    }
}
