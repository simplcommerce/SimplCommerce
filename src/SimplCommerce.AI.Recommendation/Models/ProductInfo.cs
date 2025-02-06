using Microsoft.ML.Data;

namespace SimplCommerce.AI.Recommendation.Models
{
    public class ProductInfo
    {
        [LoadColumn(0)] public float ProductID { get; set; }
        [LoadColumn(1)] public float CombinedProductID { get; set; }
    }
}