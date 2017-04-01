using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.News.Data;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Module.News.Services;
using SimplCommerce.Module.News.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.News.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/news-items")]
    public class NewsItemApiController : Controller
    {
        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly INewsItemService _newsItemService;
        private readonly IMediaService _mediaService;
        private readonly IWorkContext _workContext;

        public NewsItemApiController(IRepository<NewsItem> newsItemRepository, INewsItemService newsItemService, IMediaService mediaService, IWorkContext workContent)
        {
            _newsItemRepository = newsItemRepository;
            _newsItemService = newsItemService;
            _mediaService = mediaService;
            _workContext = workContent;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var newsItemList = _newsItemRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(newsItemList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var newsItem = _newsItemRepository.Query()
               .Include(x => x.ThumbnailImage)
               .Include(x => x.Categories)
               .FirstOrDefault(x => x.Id == id);

            var model = new NewsItemVm()
            {
                Name = newsItem.Name,
                Id = newsItem.Id,
                SeoTitle = newsItem.SeoTitle,
                ShortContent = newsItem.ShortContent,
                FullContent = newsItem.FullContent,
                IsPublished = newsItem.IsPublished,
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(newsItem.ThumbnailImage),
                NewsCategoryIds = newsItem.Categories.Select( x => x.CategoryId).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewsItemForm model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var currentUser = await _workContext.GetCurrentUser();

            if (!User.IsInRole("admin"))
            {
                return new BadRequestObjectResult(new { error = "You don't have permission to manage this news item" });
            }

            var newsItem = new NewsItem
            {
                Name = model.NewsItem.Name,
                SeoTitle = model.NewsItem.SeoTitle,
                ShortContent = model.NewsItem.ShortContent,
                FullContent = model.NewsItem.FullContent,
                IsPublished = model.NewsItem.IsPublished,
                CreatedBy = currentUser
            };

            foreach (var categoryId in model.NewsItem.NewsCategoryIds)
            {
                var newsItemCategory = new NewsItemCategory
                {
                    CategoryId = categoryId
                };
                newsItem.AddNewsItemCategory(newsItemCategory);
            }

            SaveServiceMedia(model.ThumbnailImage, newsItem);

            _newsItemService.Create(newsItem);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, NewsItemForm model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            } 

            var newsItem = _newsItemRepository.Query()
               .Include(x => x.ThumbnailImage)
               .Include(x => x.Categories)
               .FirstOrDefault(x => x.Id == id);

            var currentUser = await _workContext.GetCurrentUser();

            if (!User.IsInRole("admin"))
            {
                return new BadRequestObjectResult(new { error = "You don't have permission to manage this news item" });
            }

            newsItem.Name = model.NewsItem.Name;
            newsItem.SeoTitle = model.NewsItem.SeoTitle;
            newsItem.ShortContent = model.NewsItem.ShortContent;
            newsItem.FullContent = model.NewsItem.FullContent;
            newsItem.IsPublished = model.NewsItem.IsPublished;
            newsItem.UpdatedOn = DateTimeOffset.Now;
            newsItem.UpdatedBy = currentUser;

            AddOrDeleteCategories(model, newsItem);

            if (model.ThumbnailImage != null && newsItem.ThumbnailImage != null)
            {
                _mediaService.DeleteMedia(newsItem.ThumbnailImage);
            }

            SaveServiceMedia(model.ThumbnailImage, newsItem);

            _newsItemService.Update(newsItem);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var newsItem = _newsItemRepository.Query().FirstOrDefault(x => x.Id == id);

            if (newsItem == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();

            if (!User.IsInRole("admin"))
            {
                return new BadRequestObjectResult(new { error = "You don't have permission to manage this news item" });
            }

            _newsItemService.Delete(newsItem);

            return Ok();
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            _mediaService.SaveMedia(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }

        private void SaveServiceMedia(IFormFile image, NewsItem newsItem)
        {
            if (image != null)
            {
                var fileName = SaveFile(image);
                if (newsItem.ThumbnailImage != null)
                {
                    newsItem.ThumbnailImage.FileName = fileName;
                }
                else
                {
                    newsItem.ThumbnailImage = new Media { FileName = fileName };
                }
            }
        }

        private void AddOrDeleteCategories(NewsItemForm model, NewsItem newsItem)
        {
            foreach (var categoryId in model.NewsItem.NewsCategoryIds)
            {
                if (newsItem.Categories.Any(x => x.CategoryId == categoryId))
                {
                    continue;
                }

                var newsItemCategory = new NewsItemCategory
                {
                    CategoryId = categoryId
                };
                newsItem.AddNewsItemCategory(newsItemCategory);
            }

            var deletedNewsItemCategories =
                newsItem.Categories.Where(newsItemCategory => !model.NewsItem.NewsCategoryIds.Contains(newsItemCategory.CategoryId))
                    .ToList();

            foreach (var deletedNewsItemCategory in deletedNewsItemCategories)
            {
                deletedNewsItemCategory.NewsItem = null;
                newsItem.Categories.Remove(deletedNewsItemCategory);
            }
        }
    }
}
