using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Core.ApplicationServices
{
    public class ProductReviewService : IProductReviewService
    {
        private const string ProductReviewEntityName = "ProductReview";

        private readonly IRepository<ProductReview> productReviewRepository;
        private readonly IUrlSlugService urlSlugService;

        public ProductReviewService(IRepository<ProductReview> productReviewRepository, IUrlSlugService urlSlugService)
        {
            this.productReviewRepository = productReviewRepository;
            this.urlSlugService = urlSlugService;
        }

        public void Create(ProductReview productReview)
        {
            productReviewRepository.Add(productReview);
            productReviewRepository.SaveChange();
        }

        public void Update(ProductReview productReview)
        {
            productReviewRepository.SaveChange();
        }
    }
}
