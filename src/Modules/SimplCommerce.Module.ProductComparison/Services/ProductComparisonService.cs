using System;
using System.Collections.Generic;
using System.Text;
using SimplCommerce.Module.ProductComparison.Models;
using SimplCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SimplCommerce.Module.ProductComparison.Services
{
    public class ProductComparisonService : IProductComparisonService
    {
        private IRepository<ProductComparisonItem> _productComparisonRepository;
        public ProductComparisonService(IRepository<ProductComparisonItem> productComparisonRepository)
        {
            _productComparisonRepository = productComparisonRepository;
        }

        public ProductComparisonItem AddToComparison(long userId, long productId)
        {
            var comparisonItemQuery = _productComparisonRepository
                .Query()
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId && x.UserId == userId);

            var comparisonItem = comparisonItemQuery.FirstOrDefault();

            if (comparisonItem == null)
            {
                comparisonItem = new ProductComparisonItem
                {
                    UserId = userId,
                    ProductId = productId,
                    CreatedOn = DateTimeOffset.Now
                };

                _productComparisonRepository.Add(comparisonItem);
            }

            _productComparisonRepository.SaveChange();

            return comparisonItem;
        }

        public IList<ProductComparisonItem> GetComparisonItems(long userId)
        {
            IQueryable<ProductComparisonItem> query = _productComparisonRepository
                .Query()
                .Include(x => x.Product).ThenInclude(p => p.ThumbnailImage)
                .Include(x => x.Product).ThenInclude(p => p.OptionCombinations).ThenInclude(o => o.Option)
                .Where(x => x.UserId == userId);

            return query.ToList();
        }
    }
}
