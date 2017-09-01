using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Pricing.Models;
using SimplCommerce.Module.Pricing.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Module.Pricing.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/cartrules")]
    public class CartRuleApiController : Controller
    {
        private readonly IRepository<CartRule> _cartRuleRepository;

        public CartRuleApiController(IRepository<CartRule> cartRuleRepository)
        {
            _cartRuleRepository = cartRuleRepository;
        }

        [HttpPost("grid")]
        public IActionResult List([FromBody] SmartTableParam param)
        {
            IQueryable<CartRule> query = _cartRuleRepository
                .Query();

            var cartRules = query.ToSmartTableResult(
                param,
                cartRule => new
                {
                    cartRule.Id,
                    cartRule.Name,
                    cartRule.StartOn,
                    cartRule.EndOn,
                    cartRule.IsActive
                });

            return Json(cartRules);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var catrtRule = _cartRuleRepository.Query().Include(x => x.Coupons).FirstOrDefault(x => x.Id == id);
            var model = new CartRuleForm
            {
                Id = catrtRule.Id,
                Name = catrtRule.Name,
                Description = catrtRule.Description,
                IsActive = catrtRule.IsActive,
                StartOn = catrtRule.StartOn,
                EndOn = catrtRule.EndOn,
                IsCouponRequired = catrtRule.IsCouponRequired,
                RuleToApply = catrtRule.RuleToApply,
                DiscountAmount = catrtRule.DiscountAmount,
                DiscountStep = catrtRule.DiscountStep,
                MaxDiscountAmount = catrtRule.MaxDiscountAmount,
                UsageLimitPerCoupon = catrtRule.UsageLimitPerCoupon,
                UsageLimitPerCustomer = catrtRule.UsageLimitPerCustomer,
            };

            if(catrtRule.IsCouponRequired)
            {
                var coupon = catrtRule.Coupons.FirstOrDefault();
                if(coupon != null)
                {
                    model.CouponCode = coupon.Code;
                }
            }

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CartRuleForm model)
        {
            if (ModelState.IsValid)
            {
                var cartRule = new CartRule
                {
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = model.IsActive,
                    StartOn = model.StartOn,
                    EndOn = model.EndOn,
                    IsCouponRequired = model.IsCouponRequired,
                    RuleToApply = model.RuleToApply,
                    DiscountAmount = model.DiscountAmount,
                    DiscountStep = model.DiscountStep,
                    MaxDiscountAmount = model.MaxDiscountAmount,
                    UsageLimitPerCoupon = model.UsageLimitPerCoupon,
                    UsageLimitPerCustomer = model.UsageLimitPerCustomer
                };

                if(model.IsCouponRequired && !string.IsNullOrWhiteSpace(model.CouponCode))
                {
                    var coupon = new Coupon
                    {
                        CartRule = cartRule,
                        Code = model.CouponCode
                    };

                    cartRule.Coupons.Add(coupon);
                }

                _cartRuleRepository.Add(cartRule);
                _cartRuleRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] CartRuleForm model)
        {
            if (ModelState.IsValid)
            {
                var cartRule = _cartRuleRepository.Query().Include(x => x.Coupons).FirstOrDefault(x => x.Id == id);
                if(cartRule == null)
                {
                    return NotFound();
                }

                cartRule.Name = model.Name;
                cartRule.Description = model.Description;
                cartRule.StartOn = model.StartOn;
                cartRule.EndOn = model.EndOn;
                cartRule.IsActive = model.IsActive;
                cartRule.IsCouponRequired = model.IsCouponRequired;
                cartRule.RuleToApply = model.RuleToApply;
                cartRule.DiscountAmount = model.DiscountAmount;
                cartRule.DiscountStep = model.DiscountStep;
                cartRule.MaxDiscountAmount = model.MaxDiscountAmount;
                cartRule.UsageLimitPerCoupon = model.UsageLimitPerCoupon;
                cartRule.UsageLimitPerCustomer = model.UsageLimitPerCustomer;

                if (model.IsCouponRequired && !string.IsNullOrWhiteSpace(model.CouponCode))
                {
                    var coupon = cartRule.Coupons.FirstOrDefault();
                    if (coupon == null)
                    {
                        coupon = new Coupon
                        {
                            CartRule = cartRule,
                            Code = model.CouponCode
                        };

                        cartRule.Coupons.Add(coupon);
                    }
                    else
                    {
                        coupon.Code = model.CouponCode;
                    }
                }

                _cartRuleRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }
    }
}
