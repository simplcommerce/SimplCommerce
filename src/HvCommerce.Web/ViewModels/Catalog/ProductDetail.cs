using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HvCommerce.Core.Domain.Models;

namespace HvCommerce.Web.ViewModels.Catalog
{
    public class ProductDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<MediaViewModel> Images { get; set; } = new List<MediaViewModel>();
    }
}
