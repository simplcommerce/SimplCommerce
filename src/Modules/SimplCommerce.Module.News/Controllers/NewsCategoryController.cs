using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Module.News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplCommerce.Module.News.Controllers
{

    public class NewsCategoryController : Controller
    {
        private int _pageSize;
        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<NewsCategory> _newsCategoryRepository;

        public NewsCategoryController(IRepository<NewsItem> newsItemRepository,
            IMediaService mediaService, IRepository<NewsCategory> newsCategoryRepository,
            IConfiguration config)
        {
            _newsItemRepository = newsItemRepository;
            _mediaService = mediaService;
            _newsCategoryRepository = newsCategoryRepository;
            //Will change to News.ProductPageSize
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        public IActionResult NewsCategoryDetail(long id)
        {

            var newsCategoryList = _newsCategoryRepository.Query()
                .Include(x => x.NewsItems)
                .Where(x => !x.IsDeleted)
                .Select(x => new NewsCategoryVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    SeoTitle = x.SeoTitle
                })
                .ToList();

            if (newsCategoryList == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var currentNewsCategory = newsCategoryList.Select(x => new NewsCategoryVm()
            {
                Id = x.Id,
                Name = x.Name,
                SeoTitle = x.SeoTitle
            })
            .FirstOrDefault(x => x.Id == id);


            var newsVm = new NewsVm()
            {
                CurrentNewsCategory = currentNewsCategory,
                NewsCategory = newsCategoryList
            };

            var newsItems = _newsItemRepository.Query()
                .Include(x => x.ThumbnailImage)
                .Where(x => x.Categories.Any(c => c.CategoryId == currentNewsCategory.Id) && !x.IsDeleted && x.IsPublished)
                .OrderByDescending(x => x.CreatedOn)
                .Select( x => new NewsItemThumbnail()
                {
                    Id = x.Id,
                    ShortContent = x.ShortContent,
                    ImageUrl = _mediaService.GetMediaUrl(x.ThumbnailImage),
                    //TODO will change to PublishedOn soon
                    PublishedOn = x.CreatedOn,
                    SeoTitle = x.SeoTitle
                })
                .ToList();

            var newsByCategoryVm = new NewsByCategoryVm
            {
                NewsCategoryId = currentNewsCategory.Id,
                NewsItem = newsItems,
                TotalNews = newsItems.Count()
            };

            newsVm.NewsByCategory = newsByCategoryVm;

            return View(newsVm);
        }

    }
}
