using System.Collections.Generic;
using SimplCommerce.Module.ProductComparison.Models;

namespace SimplCommerce.Module.ProductComparison.Services
{
    public interface IProductComparisonService
    {
        void AddToComparison(long userId, long productId);
    }
}
