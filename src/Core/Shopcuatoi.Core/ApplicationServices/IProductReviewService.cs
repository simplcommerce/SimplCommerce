using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface IProductReviewService
    {
        void Create(ProductReview productReview);

        void Update(ProductReview productReview);
    }
}
