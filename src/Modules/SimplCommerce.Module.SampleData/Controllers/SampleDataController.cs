using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.SampleData.Services;

namespace SimplCommerce.Module.SampleData.Controllers
{
    public class SampleDataController : Controller
    {
        private readonly ISampleDataService _sampleDataService;

        public SampleDataController(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetToSample()
        {
            await _sampleDataService.ResetToSampleData();
            return Redirect("~/");
        }
    }
}
