using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Orders.Components
{
    public class PaymentViewComponent : ViewComponent
    {
        

        public async Task<IViewComponentResult> InvokeAsync()
        {
           // var curentUser = await _workContext.GetCurrentUser();
            //var cart = await _cartService.GetCart(curentUser.Id);

            return View("/Modules/SimplCommerce.Module.Orders/Views/Components/PaymentTypeList.cshtml");
        }
    }
}
