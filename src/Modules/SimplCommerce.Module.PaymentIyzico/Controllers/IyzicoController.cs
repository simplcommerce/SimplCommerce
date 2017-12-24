using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentIyzico.Models;
using SimplCommerce.Module.PaymentIyzico.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentIyzico.Controllers
{
    public class IyzicoController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private Lazy<IyzicoConfigForm> _setting;

        public IyzicoController(ICartService cartService, IOrderService orderService, IWorkContext workContext, IRepository<PaymentProvider> paymentProviderRepository, IRepository<Payment> paymentRepository)
        {
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
            _setting = new Lazy<IyzicoConfigForm>(GetSetting);
        }
        private IyzicoConfigForm GetSetting()
        {
            var paypalExpressProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.IyzicoProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<IyzicoConfigForm>(paypalExpressProvider.AdditionalSettings);
            return paypalExpressSetting;
        }
    }
}