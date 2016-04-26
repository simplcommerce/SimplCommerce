using System;
using Shopcuatoi.Infrastructure.Domain.Models;
using System.Collections.Generic;

namespace Shopcuatoi.Core.Domain.Models
{
    public class ProductReview : Entity
    {
        public long UserId { get; set; }

        public User User { get; set; }

        public long ProductId { get; set; }

        public bool IsApproved { get; set; }

        public string ReviewTitle { get; set; }

        public string ReviewText { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
