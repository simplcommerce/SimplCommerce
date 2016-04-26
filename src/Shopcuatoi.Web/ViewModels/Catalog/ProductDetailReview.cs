using Shopcuatoi.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductDetailReview
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public string UserName { get; set; }

        public long ProductId { get; set; }

        public bool IsApproved { get; set; }

        [Required(ErrorMessage = "Review title is required.")]
        public string ReviewTitle { get; set; }

        [Required(ErrorMessage = "Review text is required.")]
        public string ReviewText { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public IList<ProductDetailReview> Items { get; set; }
    }
}
