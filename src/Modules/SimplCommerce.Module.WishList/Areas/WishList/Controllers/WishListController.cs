using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.WishList.Models;
using SimplCommerce.Module.WishList.Services;
using SimplCommerce.Module.WishList.ViewModels;

namespace SimplCommerce.Module.WishList.Controllers
{
    [Area("WishList")]
    public class WishListController : Controller
    {
        private const int DefaultPageSize = 25;

        private readonly IRepository<Models.WishList> _wishListRepository;
        private readonly IRepository<WishListItem> _wishListItemRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IWishListService _wishListService;
        private readonly IMediaService _mediaService;
        private readonly IEmailSender _emailSender;
        private readonly IWorkContext _workContext;

        public WishListController(
            IRepository<Models.WishList> wishListRepository,
            IRepository<WishListItem> wishListItemRepository,
            IRepository<Product> productRepository,
            IWishListService wishListService,
            IMediaService mediaService,
            IEmailSender emailSender,
            IWorkContext workContext)
        {
            _wishListRepository = wishListRepository;
            _wishListItemRepository = wishListItemRepository;
            _productRepository = productRepository;
            _wishListService = wishListService;
            _mediaService = mediaService;
            _emailSender = emailSender;
            _workContext = workContext;
        }

        public IActionResult Share()
        {
            var model = new ShareWishListForm();

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Share(ShareWishListForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();

                var wishList = await _wishListRepository
                    .Query()
                    .SingleOrDefaultAsync(x => x.UserId == user.Id);

                string sharingCode = String.Empty;

                if (wishList.SharingCode == null)
                {
                    sharingCode = _wishListService.GenerateSharingCode(wishList.Id);
                    wishList.SharingCode = sharingCode;
                    await _wishListRepository.SaveChangesAsync();
                }
                else
                {
                    sharingCode = wishList.SharingCode;
                }

                var wishListUrl = Url.Action("PublicList", "WishList", new { id = sharingCode }, protocol: HttpContext.Request.Scheme);
                string emailBody = $"{user.Email} would like to share their wish list with you: {wishListUrl}"
                    + Environment.NewLine
                    + Environment.NewLine
                    + model.Message;

                await _emailSender.SendEmailAsync(model.EmailAddress, "Wish List Sharing", emailBody);

                return RedirectToAction("PrivateList");
            }

            return View(model);
        }

        [Route("user/wishlist/{pageNumber?}/{pageSize?}")]
        public async Task<IActionResult> PrivateList(int? pageNumber, int? pageSize)
        {
            var user = await _workContext.GetCurrentUser();

            var wishList = await _wishListRepository
                .Query()
                .SingleOrDefaultAsync(x => x.UserId == user.Id);

            if (wishList == null)
            {
                wishList = new Models.WishList()
                {
                    UserId = user.Id
                };

                _wishListRepository.Add(wishList);
                await _wishListRepository.SaveChangesAsync();
            }

            var wishlistVm = await List(wishList, pageNumber, pageSize);

            return View(wishlistVm);
        }

        [Route("wishlist/list/{id}/{pageNumber?}/{pageSize?}")]
        public async Task<IActionResult> PublicList(string id, int? pageNumber, int? pageSize)
        {
            var user = await _workContext.GetCurrentUser();

            var wishList = await _wishListRepository
                .Query()
                .SingleOrDefaultAsync(x => x.SharingCode == id);

            if (wishList == null)
            {
                return NotFound();
            }

            var wishlistVm = await List(wishList, pageNumber, pageSize);

            return View(wishlistVm);
        }

        private async Task<WishListVm> List(Models.WishList wishList, int? pageNumber, int? pageSize)
        {
            var itemsPerPage = pageSize.HasValue ? pageSize.Value : DefaultPageSize;
            var currentPageNum = pageNumber.HasValue ? pageNumber.Value : 1;
            var offset = (itemsPerPage * currentPageNum) - itemsPerPage;

            var wishlistVm = new WishListVm()
            {
                Id = wishList.Id,
                SharingCode = wishList.SharingCode
            };

            var wishListItemsQuery = _wishListItemRepository
                .Query()
                .Where(x => x.WishListId == wishList.Id)
                .Select(x => new WishListItemVm()
                {
                    Id = x.Id,
                    WishListId = x.WishListId,
                    ProductId = x.Product.Id,
                    ProductName = x.Product.Name,
                    Description = x.Description,
                    ProductImage = _mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    Quantity = x.Quantity
                });

            wishlistVm.Items.Data = await wishListItemsQuery
                .Skip(offset)
                .Take(itemsPerPage)
                .ToListAsync();

            wishlistVm.Items.PageNumber = currentPageNum;
            wishlistVm.Items.PageSize = itemsPerPage;
            wishlistVm.Items.TotalItems = await wishListItemsQuery.CountAsync();

            return wishlistVm;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] AddToWishList model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();
                var resultModel = new AddToWishListResult();

                var product = await _productRepository
                    .Query()
                    .Include(x => x.ThumbnailImage)
                    .SingleOrDefaultAsync(x => x.Id == model.ProductId);

                if (product == null)
                {
                    return NotFound();
                }

                var wishList = await _wishListRepository
                    .Query()
                    .Include(x => x.Items)
                    .SingleOrDefaultAsync(x => x.UserId == user.Id);

                if (wishList == null)
                {
                    wishList = new Models.WishList()
                    {
                        UserId = user.Id
                    };

                    _wishListRepository.Add(wishList);
                    await _wishListRepository.SaveChangesAsync();
                }

                var existingWishlistItem = wishList
                    .Items
                    .SingleOrDefault(x => x.ProductId == model.ProductId);

                if (existingWishlistItem != null)
                {
                    resultModel.Message = "The product already exists in your wish list";
                    resultModel.Item = new WishListItemVm()
                    {
                        Id = existingWishlistItem.Id,
                        WishListId = wishList.Id,
                        ProductName = product.Name,
                        ProductImage = _mediaService.GetThumbnailUrl(product.ThumbnailImage),
                        Quantity = existingWishlistItem.Quantity,
                    };
                }
                else
                {
                    var wishListItem = new WishListItem()
                    {
                        WishListId = wishList.Id,
                        ProductId = model.ProductId,
                        Quantity = model.Quantity
                    };

                    _wishListItemRepository.Add(wishListItem);

                    wishList.UpdatedOn = DateTimeOffset.Now;
                    await _wishListRepository.SaveChangesAsync();

                    resultModel.Message = "The product has been added to your wish list";
                    resultModel.Item = new WishListItemVm()
                    {
                        Id = wishListItem.Id,
                        WishListId = wishList.Id,
                        ProductName = product.Name,
                        ProductImage = _mediaService.GetThumbnailUrl(product.ThumbnailImage),
                        Quantity = model.Quantity,
                    };
                }

                return PartialView("AddToWishListResult", resultModel);
            }

            return NotFound();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> RemoveItem(long id)
        {
            var user = await _workContext.GetCurrentUser();

            var wishList = await _wishListRepository
                .Query()
                .Include(x => x.Items)
                .SingleOrDefaultAsync(x => x.UserId == user.Id);

            if (wishList == null)
            {
                return NotFound();
            }

            var wishListItem = wishList
                .Items
                .SingleOrDefault(x => x.Id == id);

            if (wishListItem == null)
            {
                return NotFound();
            }

            _wishListItemRepository.Remove(wishListItem);

            wishList.UpdatedOn = DateTimeOffset.Now;
            await _wishListRepository.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateWishListItem model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();
                var returnModel = new AddToWishListResult();

                var wishList = await _wishListRepository.Query()
                    .Include(x => x.Items)
                    .SingleOrDefaultAsync(x => x.UserId == user.Id);

                if (wishList == null)
                {
                    return NotFound();
                }

                var wishListItem = wishList
                    .Items
                    .SingleOrDefault(x => x.Id == model.ItemId);

                if (wishListItem == null)
                {
                    return NotFound();
                }

                wishListItem.Description = String.IsNullOrWhiteSpace(model.Description) ? null : model.Description;
                wishListItem.Quantity = model.Quantity;
                wishListItem.UpdatedOn = DateTimeOffset.Now;

                wishList.UpdatedOn = DateTimeOffset.Now;
                await _wishListRepository.SaveChangesAsync();

                return PartialView("UpdateItemResult");
            }

            return NotFound();
        }
    }
}
