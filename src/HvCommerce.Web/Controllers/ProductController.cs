using System.Data.Entity;
using System.Linq;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.ViewModels;
using HvCommerce.Web.ViewModels.Catalog;
using Microsoft.AspNet.Mvc;

namespace HvCommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IMediaService mediaService;
        private readonly IRepository<Product> productRepository;

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService,
            IRepository<Category> categoryRepository)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
            this.categoryRepository = categoryRepository;
        }

        [Route("category/{catSeoTitle}")]
        public IActionResult ProductsByCategory(string catSeoTitle)
        {
            var category = categoryRepository.Query().FirstOrDefault(x => x.SeoTitle == catSeoTitle);
            if (category == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new ProductsByCategory
            {
                CategoryName = category.Name
            };

            var products = productRepository.Query()
                .Where(x => x.Categories.Any(c => c.CategoryId == category.Id) && x.IsPublished)
                .Select(x => new ProductListItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    SeoTitle = x.SeoTitle,
                    Price = x.Price,
                    OldPrice = x.OldPrice,
                    ThumbnailImage = x.ThumbnailImage
                }).ToList();

            foreach (var product in products)
            {
                product.ThumbnailUrl = mediaService.GetThumbnailUrl(product.ThumbnailImage);
            }

            model.Products = products;

            return View(model);
        }

        [Route("product/{seoTitle}")]
        public IActionResult ProductDetail(string seoTitle)
        {
            var product = productRepository.Query()
                .Include(x => x.Medias)
                .FirstOrDefault(x => x.SeoTitle == seoTitle && x.IsPublished);
            if (product == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new ProductDetail
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };

            foreach (var mediaViewModel in product.Medias.Select(productMedia => new MediaViewModel
            {
                Url = mediaService.GetMediaUrl(productMedia.Media),
                ThumbnailUrl = mediaService.GetThumbnailUrl(productMedia.Media)
            }))
            {
                model.Images.Add(mediaViewModel);
            }

            return View(model);
        }
    }
}