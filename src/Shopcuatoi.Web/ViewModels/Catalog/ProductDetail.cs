using System.Collections.Generic;
using System.Linq;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public bool HasVariation => Variations.Any();

        public IList<ProductDetailAttribute> AvailableAttributes
        {
            get
            {
                var attributes = from attr in Variations.SelectMany(x => x.Attributes)
                    group attr by new
                    {
                        attr.AttributeId,
                        attr.AttributeName
                    }
                    into g
                    select new ProductDetailAttribute
                    {
                        AttributeId = g.Key.AttributeId,
                        AttributeName = g.Key.AttributeName,
                        Values = g.Select(x => x.Value).Distinct().ToList()
                    };

                return attributes.ToList();
            }
        }

        public IList<MediaViewModel> Images { get; set; } = new List<MediaViewModel>();

        public IList<ProductDetailVariation> Variations { get; set; } = new List<ProductDetailVariation>();
    }
}