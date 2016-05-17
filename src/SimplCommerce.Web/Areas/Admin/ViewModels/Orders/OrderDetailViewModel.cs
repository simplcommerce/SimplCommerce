using System;
using System.Collections.Generic;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Orders
{
    public class OrderDetailViewModel
    {
        public long Id { get; set; }

        public string CustomerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal SubTotal { get; set; }

        public ShippingAddressViewModel ShippingAddress { get; set; }

        public IList<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
}