using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Helpers;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.PayViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace SimplCommerce.Module.Orders.Controllers
{
    public class PaymentController : Controller
    {
        private IRepository<Order> _orderRepository;

        public PaymentController(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IActionResult> Index(int Id)
        {
            //get order
            Order order = _orderRepository.Query().Where(z=>z.Id == Id).FirstOrDefault();
            
            //first get http context
            HttpClient http = PayPalHelper.GetPaypalHttpClient();
            
            //get token from paypal
            JObject jsoncontent = await PayPalHelper.GetPayPalAccessTokenAsync(http);
            var token = jsoncontent["access_token"];
            
            //if approved then get redarecturl otherwise you will go to canceled url
            PayPalPaymentCreatedResponcse responce = await PayPalHelper.CreatePaypalPaymentAsync(http, token.ToString(), "10");

            foreach (var item in responce.links)
            {
                if (item.rel == "approval_url")
                {
                    return Redirect(item.href);
                }
            }
            return View("error");
        }
        [HttpGet]
        [Route("payment/getid")]
        public IActionResult GetId(string paymentId, string token, string PayerID)
        {
            HttpClient http = PayPalHelper.GetPaypalHttpClient();
            var payed = PayPalHelper.ExecutePaypalPaymentAsync(http, token, paymentId, PayerID);
            if (payed != null)
            {
                //create payment and make order to payed 
                return RedirectToAction("success", "payment");
            }
            return RedirectToAction("canceled", "payment");
        }
        [Route("payment/success")]
        public IActionResult Success()
        {
            
            return View();
        }
        [Route("payment/canceled")]
        public IActionResult Canceled()
        {
            

            return View();
        }
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
