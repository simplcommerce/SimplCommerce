using System.Threading.Tasks;
using SimplCommerce.Module.Cms.Models;

namespace SimplCommerce.Module.Cms.Services
{
    public interface IPageService
    {
        void Create(Page page);

        void Update(Page page);

        Task Delete(Page page);
    }
}
