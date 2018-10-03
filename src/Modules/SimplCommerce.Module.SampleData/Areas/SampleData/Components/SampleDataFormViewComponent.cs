using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.SampleData.ViewModels;

namespace SimplCommerce.Module.SampleData.Components
{
    public class SampleDataFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var sampleContentFolder = Path.Combine(GlobalConfiguration.ContentRootPath, "Modules", "SimplCommerce.Module.SampleData", "SampleContent");
            var directoryInfo = new DirectoryInfo(sampleContentFolder);
            var industries = directoryInfo.GetDirectories().Select(x => x.Name).ToList();
            var model = new SampleDataOption { AvailableIndustries = industries };
            return View(this.GetViewPath(), model);
        }
    }
}
