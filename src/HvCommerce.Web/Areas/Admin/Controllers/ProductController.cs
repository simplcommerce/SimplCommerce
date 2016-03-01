using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.Areas.Admin.ViewModels;
using HvCommerce.Web.Areas.Admin.ViewModels.SmartTable;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using HvCommerce.Web.Extensions;

namespace HvCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMediaService mediaService;
<<<<<<< 520dd682b0d38fd9d080c0eb5698d691e831a6e5

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
=======
        private readonly IRepository<Category> categoryRepository;
        private readonly IUrlSlugService urlSlugService;

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService, IUrlSlugService urlSlugService)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
<<<<<<< 755bc7e3b1cea64885ce5e0c3b675f611f16d67e
            this.categoryRepository = categoryRepository;
            this.urlSlugRepository = urlSlugRepository;
>>>>>>> Update issue #20: Shorter URL
=======
            this.urlSlugService = urlSlugService;
>>>>>>> fixed common service locator does work in Custom Route
        }

        public IActionResult List([FromBody] SmartTableParam param)
        {
            var products = productRepository.Query().Where(x => !x.IsDeleted);
            var gridData = products.ToSmartTableResult(
                param,
                x => new ProductListItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedOn = x.CreatedOn,
                        IsPublished = x.IsPublished
                    });

            return Json(gridData);
        }

        [HttpPost]
        public IActionResult Create(ProductForm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState.ToDictionary());
            }

            var product = new Product
            {
                Name = model.Product.Name,
                SeoTitle = StringHelper.ToUrlFriendly(model.Product.Name),
                ShortDescription = model.Product.ShortDescription,
                Description = model.Product.Description,
                Price = model.Product.Price,
                OldPrice = model.Product.OldPrice,
                IsPublished = model.Product.IsPublished
            };

            foreach (var categoryId in model.Product.CategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }

            if (model.ThumbnailImage != null)
            {
                var fileName = SaveFile(model.ThumbnailImage);
                product.ThumbnailImage = new Media { FileName = fileName };
            }

            // Currently model binder cannot map the collection of file productImages[0], productImages[1]
            foreach (var file in Request.Form.Files)
            {
                if (file.ContentDisposition.Contains("productImages"))
                {
                    model.ProductImages.Add(file);
                }
            }

            foreach (var file in model.ProductImages)
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

<<<<<<< 755bc7e3b1cea64885ce5e0c3b675f611f16d67e
<<<<<<< 520dd682b0d38fd9d080c0eb5698d691e831a6e5
            return Ok();
=======
            var urlSlug = new UrlSlug
            {
                EntityId = product.Id,
                EntityName = "Product",
                Slug = product.SeoTitle
            };

            urlSlugRepository.Add(urlSlug);
            urlSlugRepository.SaveChange();
=======
            urlSlugService.Add(product.SeoTitle, product.Id, "Product");
            productRepository.SaveChange();
>>>>>>> fixed common service locator does work in Custom Route

            return RedirectToAction("List");
>>>>>>> Update issue #20: Shorter URL
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}.{Path.GetExtension(originalFileName)}";
            mediaService.SaveMedia(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}