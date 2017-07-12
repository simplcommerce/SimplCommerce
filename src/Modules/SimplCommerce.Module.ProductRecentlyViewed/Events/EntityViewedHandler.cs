using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.ProductRecentlyViewed.Models;

namespace SimplCommerce.Module.ActivityLog.Events
{
    public class EntityViewedHandler : IAsyncNotificationHandler<EntityViewed>
    {
        private const long ProductEntityTypeId = 3;
        private readonly IRepository<RecentlyViewedProduct> _recentlyViewedProductRepository;
        private readonly IWorkContext _workContext;

        public EntityViewedHandler(IRepository<RecentlyViewedProduct> recentlyViewedProductRepository, IWorkContext workcontext)
        {
            _recentlyViewedProductRepository = recentlyViewedProductRepository;
            _workContext = workcontext;
        }

        public async Task Handle(EntityViewed notification)
        {
            if (notification.EntityTypeId == ProductEntityTypeId)
            {
                var user = await _workContext.GetCurrentUser();
                var recentlyViewedProduct = _recentlyViewedProductRepository.Query().FirstOrDefault(x =>
                    x.ProductId == notification.EntityId
                    && x.UserId == user.Id);

                if(recentlyViewedProduct == null)
                {
                    recentlyViewedProduct = new RecentlyViewedProduct
                    {
                        UserId = user.Id,
                        ProductId = notification.EntityId,
                        LatestViewedOn = DateTimeOffset.Now
                    };

                    _recentlyViewedProductRepository.Add(recentlyViewedProduct);
                }

                recentlyViewedProduct.LatestViewedOn = DateTimeOffset.Now;
                _recentlyViewedProductRepository.SaveChange();
            }
        }
    }
}
