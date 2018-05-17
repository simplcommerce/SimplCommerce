using System;
using System.ComponentModel.DataAnnotations.Schema;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductPriceHistory : EntityBase
    {
        public ProductPriceHistory()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public Product Product { get; set; }

        public  User CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public decimal? Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        [NotMapped]
        public bool IsPriceChange { get; set; }
    }
}
