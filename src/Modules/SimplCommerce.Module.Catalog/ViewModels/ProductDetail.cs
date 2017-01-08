using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }

        public bool HasVariation => Variations.Any();

        public IList<ProductDetailOption> AvailableOptions
        {
            get
            {
                var options = from opt in Variations.SelectMany(x => x.Options)
                              group opt by new
                              {
                                  opt.OptionId,
                                  opt.OptionName
                              }
                    into g
                              select new ProductDetailOption
                              {
                                  OptionId = g.Key.OptionId,
                                  OptionName = g.Key.OptionName,
                                  Values = g.Select(x => x.Value).Distinct().ToList()
                              };

                return options.ToList();
            }
        }

        public IList<MediaViewModel> Images { get; set; } = new List<MediaViewModel>();

        public IList<ProductDetailVariation> Variations { get; set; } = new List<ProductDetailVariation>();

        public IList<ProductDetailAttribute> Attributes { get; set; } = new List<ProductDetailAttribute>();

        public IList<ProductDetailCategory> Categories { get; set; } = new List<ProductDetailCategory>();
    }
}
