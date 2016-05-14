using System;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Orders
{
    public class OrderListItem
    {
        public long Id { get; set; }

        public string CustomerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal SubTotal { get; set; }
    }
}