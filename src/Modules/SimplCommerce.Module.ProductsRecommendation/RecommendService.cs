using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.Recommender;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.ProductsRecommendation.Common;
using SimplCommerce.Module.ProductsRecommendation.Models;
using static Microsoft.ML.DataOperationsCatalog;

namespace SimplCommerce.Module.ProductsRecommendation
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MLContext _mlContext;
        private readonly ILogger _logger;
        private TrainTestData _trainTestData;
        private EstimatorChain<MatrixFactorizationPredictionTransformer> _pipeline;
        private ITransformer _model;
        private IDataView _data;
        private PredictionEngine<ProductInfo, ProductPrediction> _predictEngine;

        private static string modelPath = Path.Combine(Environment.CurrentDirectory, "MLModels/model.zip");

        public RecommendationService(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger<RecommendationService>();
            _mlContext = new MLContext();
            LoadRecommendationModel();
        }

        public void BuildRecommendationModel()
        {
            _logger.LogInformation($"{nameof(RecommendationService)} is initializing...");

            var hasData = InitializeData();
            if (hasData)
            {
                _logger.LogInformation($"{nameof(RecommendationService)} is training...");

                // train the model
                TrainModel();

                // evaluate the model performance 
                EvaluateModel();

                // check how well products 3 and 63 go together
                CreatePredictEngine();

                // expose model to filePath
                ExposeModelToPath(modelPath);
            }

            _logger.LogInformation($"{nameof(RecommendationService)} is trained.");
        }

        private void LoadRecommendationModel()
        {
            // load model from filePath
            var hasModel = LoadTrainedModel(modelPath);

            if (hasModel)
            {
                CreatePredictEngine();
            }
        }

        private bool InitializeData()
        {
            var dbset = LoadDatasetFromDB();

            if (!dbset.Any())
            {
                return false;
            }

            _data = _mlContext.Data.LoadFromEnumerable<ProductInfo>(dbset);

            // split the data into 80% training and 20% testing partitions
            _trainTestData = _mlContext.Data.TrainTestSplit(_data, testFraction: 0.2);

            // prepare matrix factorization options
            var options = new MatrixFactorizationTrainer.Options()
            {
                MatrixColumnIndexColumnName = "ProductIDEncoded",
                MatrixRowIndexColumnName = "CombinedProductIDEncoded",
                LabelColumnName = "CombinedProductID",
                LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                Alpha = 0.01,
                Lambda = 0.025,
            };

            // set up a training pipeline
            // map ProductID and CombinedProductID to keys
            _pipeline = _mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "ProductID",
                    outputColumnName: "ProductIDEncoded")
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "CombinedProductID",
                    outputColumnName: "CombinedProductIDEncoded"))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(options));

            return true;
        }

        private IEnumerable<ProductInfo> LoadDatasetFromDB()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetRequiredService<IRepository<Order>>();

                var orderWithItems = orderRepository.Query()
                                .Include(x => x.OrderItems)
                                .Select(x => x.OrderItems)
                                .ToList();

                var combinnedItems = orderWithItems.SelectMany(items => Helper.CombinationsRosettaWoRecursion<OrderItem>(items.ToArray(), 2));

                var combinnedIds = combinnedItems.Select(x => new ProductInfo() { ProductID = x[0].ProductId, CombinedProductID = x[1].ProductId }).Distinct();

                return combinnedIds;
            }
        }

        private void TrainModel()
        {
            _model = _pipeline.Fit(_trainTestData.TrainSet);
        }

        private void EvaluateModel()
        {
            // evaluate the model performance 
            var predictions = _model.Transform(_trainTestData.TestSet);
            var metrics = _mlContext.Regression.Evaluate(predictions, labelColumnName: "CombinedProductID", scoreColumnName: "Score");
            _logger.LogInformation($"  RMSE: {metrics.RootMeanSquaredError:#.##}");
            _logger.LogInformation($"  L1:   {metrics.LossFunction:#.##}");
        }

        private void CreatePredictEngine()
        {
            _predictEngine = _mlContext.Model.CreatePredictionEngine<ProductInfo, ProductPrediction>(_model);
        }

        public ProductPrediction Predict(ProductInfo product)
        {
            if (_predictEngine == null)
            {
                return new ProductPrediction() { Score = 1 };
            }

            var result = _predictEngine.Predict(product);
            // Console.WriteLine($"  Score:{result.Score}\tProductID: {product.ProductID}\tCombinedProductID: {product.CombinedProductID}");
            return result;
        }

        private void ExposeModelToPath(string filePath)
        {
            _logger.LogInformation($"Expose model to {filePath}");
            _mlContext.Model.Save(_model, _data.Schema, filePath);
        }

        private bool LoadTrainedModel(string filePath)
        {
            _logger.LogInformation($"Load model from {filePath}");

            if (File.Exists(filePath))
            {
                DataViewSchema modelSchema;
                _model = _mlContext.Model.Load(filePath, out modelSchema);
                return true;
            }

            return false;
        }
    }
}
