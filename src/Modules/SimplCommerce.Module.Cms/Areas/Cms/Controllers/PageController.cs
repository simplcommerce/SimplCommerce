using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Models;

namespace SimplCommerce.Module.Cms.Areas.Cms.Controllers
{
    [Area("Cms")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PageController : Controller
    {
        private readonly IRepository<Page> _pageRepository;

        public PageController(IRepository<Page> pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IActionResult PageDetail(long id)
        {
            var page = _pageRepository.Query().FirstOrDefault(x => x.Id == id);

            return View(page);
        }
    }
}
