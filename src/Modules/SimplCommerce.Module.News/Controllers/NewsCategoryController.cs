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
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        public IActionResult NewsCategoryDetail(long id)
        {

            var newsCategoryList = _newsCategoryRepository.Query()
                .Include( x => x.NewsItems)
                .Where(x => !x.IsDeleted).ToList();

            if (newsCategoryList == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var selectedNewsCategory = newsCategoryList.FirstOrDefault(x => x.Id == id);        

            var newsVm = new NewsVm();

            var newsItems = _newsItemRepository.Query()
                .Include(x => x.ThumbnailImage)
                .Where(x => x.Categories.Any(c => c.CategoryId == selectedNewsCategory.Id) && !x.IsDeleted && x.IsPublished)
                .OrderByDescending( x => x.CreatedOn)
                .ToList();

            var newsByCategoryVm = new NewsByCategoryVm
            {
                NewsCategoryId = selectedNewsCategory.Id,
                TotalNews = newsItems.Count()
            };
            
            foreach ( var item in newsItems)
            {
                var newsItem = new NewsItemThumbnail()
                {
                    Id = item.Id,
                    ShortContent = item.ShortContent,
                    ImageUrl = _mediaService.GetMediaUrl(item.ThumbnailImage),
                    //TODO will change to PublishedOn soon
                    PublishedOn = item.CreatedOn
                };

                newsByCategoryVm.NewsItem.Add(newsItem);
            }

            newsVm.NewsByCategory = newsByCategoryVm;

            foreach ( var item in newsCategoryList)
            {
                var newsCategory = new NewsCategoryVm()
                {
                    SeoTitle = item.SeoTitle,
                    Name = item.Name

                };
                newsVm.NewsCategory.Add(newsCategory);
            }

            return View(newsVm);
        }

    }
}
