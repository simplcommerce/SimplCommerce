using Microsoft.ML;
using SimplCommerce.AI.Recommendation.Models;

namespace SimplCommerce.AI.Recommendation
{
    public interface IRecommendationService
    {
        void BuildRecommendationModel();
        ProductPrediction Predict(ProductInfo product);
    }
}