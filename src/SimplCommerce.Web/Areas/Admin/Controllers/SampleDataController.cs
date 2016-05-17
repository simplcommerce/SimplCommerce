using System.Collections.Generic;
using System.IO;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    public class SampleDataController : Controller
    {
        private readonly ISqlRepository sqlRepository;

        public SampleDataController(ISqlRepository sqlRepository)
        {
            this.sqlRepository = sqlRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetToSample()
        {
            var filePath = Path.Combine(GlobalConfiguration.ApplicationPath, "SampleData", "ResetToSampleData.sql");
            var lines = System.IO.File.ReadLines(filePath);
            var commands = sqlRepository.ParseCommand(lines);
            sqlRepository.RunCommands(commands);

            CopyImages();

            return Redirect("~/");
        }

        private void CopyImages()
        {
            var sourceDir = Path.Combine(GlobalConfiguration.ApplicationPath, "SampleData", "ProductImages");
            var destDir = Path.Combine(GlobalConfiguration.ApplicationPath, "UserContents");
            IEnumerable<string> files = Directory.GetFiles(sourceDir);
            foreach (var file in files)
            {
                var destFileName = Path.Combine(destDir, Path.GetFileName(file));
                System.IO.File.Copy(file, destFileName, true);
            }
        }
    }
}