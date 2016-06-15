using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Web.ViewModels.Cart
{
    public class CartListItem
    {
        public long Id { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductPriceString => string.Concat(ProductPrice.ToString("N0", new CultureInfo("VN-vi")), " VND");

        public int Quantity { get; set; }

        public decimal Total => Quantity * ProductPrice;

        public string TotalString => string.Concat(Total.ToString("N0", new CultureInfo("VN-vi")), " VND");

        public IEnumerable<ProductVariationOption> VariationOptions { get; set; } = new List<ProductVariationOption>();

        public static IEnumerable<ProductVariationOption> GetVariationOption(Product variation)
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
