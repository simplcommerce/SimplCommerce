using Microsoft.AspNet.Mvc;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Web.Controllers
{
    public class PageController : Controller
    {
        private readonly IRepository<Page> pageRepository;

        public PageController(IRepository<Page> pageRepository)
        {
            this.pageRepository = pageRepository;
        }

        public IActionResult PageDetail(long id)
        {
            var page = pageRepository.Get(id);

            return View(page);
        }
    }
}