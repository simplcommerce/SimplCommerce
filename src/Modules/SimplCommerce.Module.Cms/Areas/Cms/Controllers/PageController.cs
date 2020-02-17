using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Areas.Cms.ViewModels;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Areas.Cms.Controllers
{
    [Area("Cms")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PageController : Controller
    {
        private readonly IRepository<Page> _pageRepository;
        private readonly IContentLocalizationService _contentLocalizationService;

        public PageController(IRepository<Page> pageRepository, IContentLocalizationService contentLocalizationService)
        {
            _pageRepository = pageRepository;
            _contentLocalizationService = contentLocalizationService;
        }

        public IActionResult PageDetail(long id)
        {
            var page = _pageRepository.Query().FirstOrDefault(x => x.Id == id);

            if(page == null)
            {
                return NotFound();
            }

            var model = new PageVm
            {
                Name = _contentLocalizationService.GetLocalizedProperty(page, nameof(page.Name), page.Name),
                Body = _contentLocalizationService.GetLocalizedProperty(page, nameof(page.Body), page.Body),
                MetaTitle = page.MetaTitle,
                MetaKeywords = page.MetaKeywords,
                MetaDescription = page.MetaDescription
            };

            return View(model);
        }
    }
}
