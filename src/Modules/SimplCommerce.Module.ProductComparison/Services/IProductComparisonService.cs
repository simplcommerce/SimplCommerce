using SimplCommerce.Module.ProductComparison.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.ProductComparison.Services
{
    public interface IProductComparisonService
    {
        ProductComparisonItem AddToComparison(long userId, long productId);
    }
}
