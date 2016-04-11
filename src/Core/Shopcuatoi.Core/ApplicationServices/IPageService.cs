using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface IPageService
    {
        void Create(Page page);

        void Update(Page page);

        void Delete(Page page);
    }
}
