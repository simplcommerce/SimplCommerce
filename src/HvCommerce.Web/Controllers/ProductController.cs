using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.ViewModels;
using HvCommerce.Web.ViewModels.Catalog;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Server.Kestrel.Http;

namespace HvCommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMediaService mediaService;

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
        }

        [Route("product/{seoTitle}")]
        public IActionResult ProductDetail(string seoTitle)
        {
            var product = productRepository.Query().FirstOrDefault(x => x.SeoTitle == seoTitle && x.IsPublished);
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
