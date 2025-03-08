using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SimplCommerce.AI.Recommendation
{
    public class RecommendationTrainingBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public RecommendationTrainingBackgroundService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger<RecommendationTrainingBackgroundService>();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(RecommendationTrainingBackgroundService)} is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"{nameof(RecommendationTrainingBackgroundService)} is working.");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var recommendationService = scope.ServiceProvider.GetRequiredService<IRecommendationService>();

                    recommendationService.BuildRecommendationModel();
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }

    }
}