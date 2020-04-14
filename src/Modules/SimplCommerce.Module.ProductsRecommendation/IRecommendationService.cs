using Microsoft.ML;
using SimplCommerce.Module.ProductsRecommendation.Models;

namespace SimplCommerce.Module.ProductsRecommendation
{
    public interface IRecommendationService
    {
        void BuildRecommendationModel();
        ProductPrediction Predict(ProductInfo product);
    }
}
