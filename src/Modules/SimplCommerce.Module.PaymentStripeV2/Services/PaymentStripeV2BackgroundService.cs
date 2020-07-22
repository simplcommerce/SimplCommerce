using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripeV2.Extensions;
using SimplCommerce.Module.PaymentStripeV2.Models;

namespace SimplCommerce.Module.PaymentStripeV2.Services
{
    public class PaymentStripeV2BackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        private readonly string _serviceName;
        private readonly string _environmentName;

        public PaymentStripeV2BackgroundService(IServiceProvider serviceProvider, ILogger<PaymentStripeV2BackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _serviceName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            _environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{_serviceName} is starting.");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"{_serviceName} is working.");
                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var paymentAttemptRepository = scope.ServiceProvider.GetRequiredService<IRepository<PaymentAttempt>>();
                    await ProcessPendingPaymentAttempts(paymentAttemptRepository);
                }
            }
        }

        private async Task ProcessPendingPaymentAttempts(IRepository<PaymentAttempt> paymentAttemptRepository)
        {
            try
            {
                var periodToProcess = DateTimeOffset.Now.AddMinutes(-5);
                var openPaymentAttempts = await paymentAttemptRepository.Query()
                    .Include(x => x.Cart).ThenInclude(x => x.Customer)
                    .Where(x => x.IsProcessed == false
                        && x.PaymentProviderId == PaymentProviderHelper.StripeProviderId
                        && x.Environment == _environmentName
                        && x.LatestUpdatedOn < periodToProcess).ToListAsync();

                foreach (var paymentAttempt in openPaymentAttempts)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(paymentAttempt.PaymentAttemptId))
                        {
                            paymentAttempt.IsProcessed = true;
                            paymentAttempt.UpdatedNow();
                            paymentAttempt.AdditionalInformation = paymentAttempt.GetAdditionalInfos().AddInfo($"Empty Id. Closed by {_serviceName}.").ConvertToJson();
                            await paymentAttemptRepository.SaveChangesAsync();
                        }
                        else
                        {
                            using (var scope = _serviceProvider.CreateScope())
                            {
                                var paymentStripeV2Service = scope.ServiceProvider.GetRequiredService<IPaymentStripeV2Service>();
                                await paymentStripeV2Service.CreateOrderForUser(paymentAttempt.Id, paymentAttempt.Cart.Customer.Culture);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error while processing {paymentAttempt.GetType().Name} with {nameof(paymentAttempt.Id)}={paymentAttempt.Id}.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while processing {typeof(PaymentAttempt).Name}s.");
            }
        }
    }
}
