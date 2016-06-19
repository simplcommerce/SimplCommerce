using SimplCommerce.Cms.Domain.Models;

namespace SimplCommerce.Cms.ApplicationServices
{
    public interface IPageService
    {
        void Create(Page page);

        void Update(Page page);

        void Delete(Page page);
    }
}
