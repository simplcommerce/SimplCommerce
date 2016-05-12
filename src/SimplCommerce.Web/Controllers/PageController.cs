using Microsoft.AspNet.Mvc;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Web.Controllers
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