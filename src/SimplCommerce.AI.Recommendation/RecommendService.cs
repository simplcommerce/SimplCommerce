using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.Recommender;
using SimplCommerce.AI.Recommendation.Models;
using static Microsoft.ML.DataOperationsCatalog;

namespace SimplCommerce.AI.Recommendation
{
    public class RecommendationService : IRecommendationService
    {
        private readonly MLContext _mlContext;
        private readonly ILogger _logger;
        private TrainTestData _trainTestData;
        private EstimatorChain<MatrixFactorizationPredictionTransformer> _pipeline;
        private ITransformer _model;
        private IDataView _data;
        public PredictionEngine<ProductInfo, ProductPrediction> predictEngine;

        private static string dataPath = Path.Combine(Environment.CurrentDirectory, "MLData/data.txt");
        private static string modelPath = Path.Combine(Environment.CurrentDirectory, "MLModels/model.zip");

        public RecommendationService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RecommendationService>();
            _mlContext = new MLContext();
        }

        public void BuildRecommendationModel()
        {
            _logger.LogInformation($"{nameof(RecommendationService)} is training.");

            // setting and initialize
            Initialize(dataPath);

            // train the model
            TrainModel();

            // evaluate the model performance
            EvaluateModel();

            // check how well products 3 and 63 go together
            CreatePredictEngine();

            // expose model to filePath
            ExposeModelToPath(modelPath);

            _logger.LogInformation($"{nameof(RecommendationService)} is trained.");
        }

        private void LoadRecommendationModel()
        {
            // load model from filePath
            LoadTrainedModel(modelPath);
            CreatePredictEngine();
        }

        private void Initialize(string dataPath)
        {
            // load the dataset in memory
            _logger.LogInformation("Loading data...");

            _data = _mlContext.Data.LoadFromTextFile<ProductInfo>(
                dataPath,
                hasHeader: false,
                separatorChar: '\t');

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
            // step 1: map ProductID and CombinedProductID to keys
            _pipeline = _mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "ProductID",
                    outputColumnName: "ProductIDEncoded")
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "CombinedProductID",
                    outputColumnName: "CombinedProductIDEncoded"))

                // step 2: find recommendations using matrix factorization
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(options));
        }

        private void TrainModel()
        {
            _logger.LogInformation("Training the model...");
            _model = _pipeline.Fit(_trainTestData.TrainSet);
        }

        private void EvaluateModel()
        {
            // evaluate the model performance
            _logger.LogInformation("Evaluating the model...");
            var predictions = _model.Transform(_trainTestData.TestSet);
            var metrics = _mlContext.Regression.Evaluate(predictions, labelColumnName: "CombinedProductID", scoreColumnName: "Score");
            _logger.LogInformation($"  RMSE: {metrics.RootMeanSquaredError:#.##}");
            _logger.LogInformation($"  L1:   {metrics.LossFunction:#.##}");
        }

        private void CreatePredictEngine()
        {
            _logger.LogInformation("Create predict engine...");
            predictEngine = _mlContext.Model.CreatePredictionEngine<ProductInfo, ProductPrediction>(_model);
        }

        public ProductPrediction Predict(ProductInfo product)
        {
            if (predictEngine == null)
            {
                return new ProductPrediction() { Score = 1 };
            }

            var result = predictEngine.Predict(product);
            // Console.WriteLine($"  Score:{result.Score}\tProductID: {product.ProductID}\tCombinedProductID: {product.CombinedProductID}");
            return result;
        }

        private void ExposeModelToPath(string filePath)
        {
            _logger.LogInformation($"Expose model to {filePath}");

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            _mlContext.Model.Save(_model, _data.Schema, filePath);
        }

        private void LoadTrainedModel(string filePath)
        {
            _logger.LogInformation($"Load model from {filePath}");
            DataViewSchema modelSchema;
            _model = _mlContext.Model.Load(filePath, out modelSchema);
        }
    }
}
