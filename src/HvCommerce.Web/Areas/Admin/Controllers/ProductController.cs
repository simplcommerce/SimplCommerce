using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.Areas.Admin.Helpers;
using HvCommerce.Web.Areas.Admin.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;

namespace HvCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMediaService mediaService;
        private readonly IRepository<Category> categoryRepository; 

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService, IRepository<Category> categoryRepository)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult ListAjax([DataSourceRequest] DataSourceRequest request)
        {
            var products = productRepository.Query().Where(x => !x.IsDeleted);
            var gridData = products.ToDataSourceResult(
                request,
                x => new ProductListItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedOn = x.CreatedOn,
                        IsPublished = x.IsPublished
                    });

            return Json(gridData);
        }

        public IActionResult Create()
        {
            var model = new ProductForm();
            AddCategoryListToForm();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductForm model, IFormFile thumbnailImage, ICollection<IFormFile> images)
        {
            if (!ModelState.IsValid)
            {
                AddCategoryListToForm();
                return View(model);
            }

            var product = new Product
            {
                Name = model.Name,
                SeoTitle = StringHelper.ToUrlFriendly(model.Name),
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                Price = model.Price,
                OldPrice = model.OldPrice,
                IsPublished = model.IsPublished
            };

            foreach (var categoryId in model.CategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }

            if (thumbnailImage != null)
            {
                var fileName = SaveFile(thumbnailImage);
                product.ThumbnailImage = new Media { FileName = fileName };
            }

            foreach (var file in images)
            {
                var fileName = SaveFile(file);
                var productMedia = new ProductMedia
                {
                    Product = product,
                    Media = new Media { FileName = fileName }
                };
                product.AddMedia(productMedia);
            }

            productRepository.Add(product);
            productRepository.SaveChange();

            return RedirectToAction("List");
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}.{Path.GetExtension(originalFileName)}";
            mediaService.SaveMedia(file.OpenReadStream(), fileName);
            return fileName;
        }

        private void AddCategoryListToForm()
        {
            var categories = categoryRepository.Query().Where(x => !x.IsDeleted).ToList();

            var categoryListItem = CategoryMapper.ToCategoryListItem(categories)
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                    .ToList();
            ViewBag.Categories = categoryListItem;
        }
    }
}