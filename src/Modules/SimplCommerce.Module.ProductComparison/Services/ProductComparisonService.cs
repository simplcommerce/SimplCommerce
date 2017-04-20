using System;
using System.Collections.Generic;
using System.Text;
using SimplCommerce.Module.ProductComparison.Models;

namespace SimplCommerce.Module.ProductComparison.Services
{
    public class ProductComparisonService : IProductComparisonService
    {
        private const int MaxProduct = 3;

        public ProductComparisonService()
        {

        }
        public ProductComparisonItem AddToComparison(long userId, long productId)
        {
            throw new NotImplementedException();
        }
    }
}
