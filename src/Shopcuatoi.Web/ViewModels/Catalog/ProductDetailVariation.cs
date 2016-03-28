using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductDetailVariation
    {
        public long Id { get; set; }

        public decimal? PriceOffset { get; set; }

        public IList<ProductDetailVariationAttribute> Attributes { get; protected set; } = new List<ProductDetailVariationAttribute>();
    }
}
