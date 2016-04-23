using System.Collections.Generic;
using System.Linq;
using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Web.ViewModels.Cart
{
    public class CartListItem
    {
        public long Id { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice => Quantity * ProductPrice;

        public IEnumerable<ProductVariationOption> VariationOptions { get; set; } = new List<ProductVariationOption>();

        public static IEnumerable<ProductVariationOption> GetVariationOption(ProductVariation variation)
        {
            if (variation == null)
            {
                return new List<ProductVariationOption>();
            }

            return variation.OptionCombinations.Select(x => new ProductVariationOption
            {
                OptionName = x.Option.Name,
                Value = x.Value
            });
        }
    }
}
