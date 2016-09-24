using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Search.Models;

namespace SimplCommerce.Module.Search.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/search")]
    public class SearchApiController : Controller
    {
        private readonly IRepository<Query> _queryRepository;

        public SearchApiController(IRepository<Query> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        [HttpGet("most-search-keywords")]
        public IActionResult MostSearchKeywords()
        {
            var model = _queryRepository.Query()
                .GroupBy(x => x.QueryText)
                .OrderByDescending(g => g.Count())
                .Select(g => new {Keyword = g.Key, Count = g.Count()})
                .Take(5);

            return Json(model);
        }
    }
}
