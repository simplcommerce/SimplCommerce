namespace Shopcuatoi.Web.Areas.Admin.ViewModels.Pages
{
    public class PageForm
    {
        public PageForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string SeoTitle { get; set; }

        public string Body { get; set; }

        public bool IsPublished { get; set; }
    }
}