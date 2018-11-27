namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductPriceItemForm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal? NewPrice { get; set; }

        public decimal? NewOldPrice { get; set; }
    }
}
