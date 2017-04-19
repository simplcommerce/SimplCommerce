using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Module.News.ViewModels;

namespace SimplCommerce.Module.News.Controllers
{
    public class NewsItemController : Controller
    {
        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly IMediaService _mediaService;

        public NewsItemController(IRepository<NewsItem> newsItemRepository,
            IMediaService mediaService,
            IConfiguration config)
        {
            _newsItemRepository = newsItemRepository;
            _mediaService = mediaService;
        }

        public IActionResult NewsItemDetail(long id)
        {
            var newsItem = _newsItemRepository.Query()
                .Include(x => x.ThumbnailImage)
                .FirstOrDefault(x => x.Id == id && x.IsPublished && !x.IsDeleted);

            if (newsItem == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new NewsItemVm()
            {
                Name = newsItem.Name,
                FullContent = newsItem.FullContent,
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(newsItem.ThumbnailImage)
            };

            return View(model);
        }
    }
}
