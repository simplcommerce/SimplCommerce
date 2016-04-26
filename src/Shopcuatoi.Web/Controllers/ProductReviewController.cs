using System.Data.Entity;
using System.Linq;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.ViewModels.Catalog;
using Microsoft.AspNet.Mvc;
using System;
using Microsoft.AspNet.Authorization;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Shopcuatoi.Web.Controllers
{
    [Authorize]
    public class ProductReviewController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductReview> productReviewRepository;
        private readonly IProductReviewService productReviewService;
        private readonly UserManager<User> userManager;

        public ProductReviewController(IRepository<Product> productRepository, IRepository<ProductReview> productReviewRepository, IProductReviewService productReviewService, UserManager<User> userManager)
        {
            this.productRepository = productRepository;
            this.productReviewRepository = productReviewRepository;
            this.productReviewService = productReviewService;
            this.userManager = userManager;
        }

        public IActionResult Reviews(long Id, bool sucessfullyAdded = false)
        {
            var product = productRepository.Get(Id);

            if (product == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new ProductDetailReview();

            model.Items = productReviewRepository.Query().Include( u => u.User)
                                                .Where(x => x.ProductId == Id && x.IsApproved)
                                                .Select(x => new ProductDetailReview
                                                {
                                                    Id = x.Id,
                                                    UserName = x.User.FullName,
                                                    ProductId = x.ProductId,
                                                    IsApproved = x.IsApproved,
                                                    ReviewTitle = x.ReviewTitle,
                                                    ReviewText = x.ReviewText,
                                                    Rating = x.Rating,
                                                    CreatedOn = x.CreatedOn
                                                }).ToList();

            ViewBag.ProductName = product.Name;
            ViewBag.ProductId = product.Id;
            ViewBag.SucessfullyAdded = sucessfullyAdded;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (ProductDetailReview model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.FindByIdAsync(HttpContext.User.GetUserId());

                if (currentUser == null)
                {
                    return Redirect("~/Error/FindNotFound");
                }

                var review = new ProductReview
                {
                    ReviewText = model.ReviewText,
                    ReviewTitle = model.ReviewTitle,
                    Rating = model.Rating,
                    ProductId = model.ProductId,
                    UserId = currentUser.Id,
                    CreatedOn = DateTime.Now,
                    IsApproved = true
                };

                productReviewService.Create(review);

                return RedirectToAction("Reviews", new { Id = model.ProductId, sucessfullyAdded = true });
            }

            return new BadRequestObjectResult(ModelState);
        }
    }
}
