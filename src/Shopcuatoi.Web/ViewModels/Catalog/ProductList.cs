using System.Collections.Generic;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductList
    {
        public ProductList()
        {
            ItemsPerRow = 3;
        }

        public ProductList(IList<ProductListItem> items) : this()
        {
            Items = items;
        }

        public ProductList(IList<ProductListItem> items, int itemsPerRow) : this(items)
        {
            ItemsPerRow = itemsPerRow;
        }

        public IList<ProductListItem> Items { get; set; }

        public int ItemsPerRow { get; set; }
    }
}