using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Inventory.Models;

namespace SimplCommerce.Module.Inventory.Services
{
    public class StockSubscriptionService : IStockSubscriptionService
    {
        private readonly IRepository<BackInStockSubscription> _backInStockSubscriptionRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IEmailSender _emailSender;
        private readonly IRazorViewRenderer _viewRender;

        public StockSubscriptionService(IRepository<BackInStockSubscription> backInStockSubscriptionRepository, IEmailSender emailSender, IRazorViewRenderer viewRender, IRepository<Product> productRepository)
        {
            _backInStockSubscriptionRepository = backInStockSubscriptionRepository;
            _emailSender = emailSender;
            _viewRender = viewRender;
            _productRepository = productRepository;
        }

        public async Task BackInStockSendNotificationsAsync(long productId)
        {
            var subscriptions = await _backInStockSubscriptionRepository
                .Query()
                .Where(o => o.ProductId == productId)
                .ToListAsync();

            var product = await _productRepository
                .Query()
                .Where(o => o.Id == productId)
                .Include(o => o.ThumbnailImage)
                .FirstOrDefaultAsync();

            var emailBody = await _viewRender.RenderViewToStringAsync("/Areas/Inventory/Views/EmailTemplates/BackInStockEmail.cshtml", product);
            var emailSubject = $"Back in stock";
            
            foreach (var subscription in subscriptions)
            {
                await _emailSender.SendEmailAsync(subscription.CustomerEmail, emailSubject, emailBody, true);
                
                _backInStockSubscriptionRepository.Remove(subscription);
            }

            await _backInStockSubscriptionRepository.SaveChangesAsync();
        }

        public async Task BackInStockSubscribeAsync(long productId, string customerEmail)
        {
            var subscription = new BackInStockSubscription
            {
                ProductId = productId,
                CustomerEmail = customerEmail
            };

            _backInStockSubscriptionRepository.Add(subscription);
            await _backInStockSubscriptionRepository.SaveChangesAsync();
        }
    }
}
