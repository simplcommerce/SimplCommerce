using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface IPageService
    {
        void Create(Page page);

        void Update(Page page);

        void Delete(Page page);
    }
}
