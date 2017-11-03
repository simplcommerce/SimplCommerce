using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentType.Controllers
{
    [Route("api/paymenttype")]
    public class PaymentTypeApiController : Controller
    {
        private readonly IRepository<PaymentType.Models.PaymentType> _paymentRepository;
        private readonly IWorkContext _workContext;
    

        public PaymentTypeApiController(
            IWorkContext workContext, 
            IRepository<PaymentType.Models.PaymentType> paymentRepository
            )
        {
            _workContext = workContext;
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = _paymentRepository.Query().ToList();
            //var currentUser = await _workContext.GetCurrentUser();
            return Json(query);
        }

       
    }
}
