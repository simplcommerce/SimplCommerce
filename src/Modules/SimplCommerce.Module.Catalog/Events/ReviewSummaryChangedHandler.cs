using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Events;

namespace SimplCommerce.Module.Catalog.Events
{
    public class ReviewSummaryChangedHandler : INotificationHandler<ReviewSummaryChanged>
    {
        private readonly IRepository<Product> _productRepository;

        public ReviewSummaryChangedHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ReviewSummaryChanged notification, CancellationToken cancellationToken)
        {
            if (notification.EntityTypeId == 3)
            {
                var product = await _productRepository.Query().FirstAsync(x => x.Id == notification.EntityId);
                product.ReviewsCount = notification.ReviewsCount;
                product.RatingAverage = notification.RatingAverage;
            }
        }
    }
}
