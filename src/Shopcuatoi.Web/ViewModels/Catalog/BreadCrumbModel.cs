namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class BreadcrumbModel
    {
        public BreadcrumbCategory BreadcrumbCategory { get; set; }
        public BreadcrumbDetail BreadcrumbDetail { get; set; }
    }

    public class BreadcrumbCategory
    {
        public string CategoryName { get; set; }
        public string CategorySeoTitle { get; set; }
    }

    public class BreadcrumbDetail
    {
        public string Name { get; set; }
        public string SeoTitle { get; set; }
    }
}