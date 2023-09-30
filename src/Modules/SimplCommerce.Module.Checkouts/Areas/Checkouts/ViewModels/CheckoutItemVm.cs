using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels
{
    public class CheckoutItemVm
    {
        private readonly ICurrencyService _currencyService;

        public CheckoutItemVm(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public long Id { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductPriceString => _currencyService.FormatCurrency(ProductPrice);

        public int ProductStockQuantity { get; set; }

        public bool ProductStockTrackingIsEnabled { get; set; }

        public bool IsProductAvailabeToOrder { get; set; }

        public int Quantity { get; set; }

        public decimal Total => Quantity * ProductPrice;

        public string TotalString => _currencyService.FormatCurrency(Total);

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
