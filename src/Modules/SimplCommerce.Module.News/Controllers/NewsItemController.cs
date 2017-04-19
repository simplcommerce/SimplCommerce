using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.News.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.News.Controllers
{

    public class NewsItemController : Controller
    {
        private int _pageSize;
        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<NewsCategory> _newsCategoryRepository;

        public NewsItemController(IRepository<NewsItem> newsItemRepository,
            IMediaService mediaService, IRepository<NewsCategory> newsCategoryRepository,
            IConfiguration config)
        {
            _newsItemRepository = newsItemRepository;
            _mediaService = mediaService;
            _newsCategoryRepository = newsCategoryRepository;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        public IActionResult NewsItemDetail(long id)
        {
            return View();
        }
    }
}
