using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.SampleData.Data;

namespace SimplCommerce.Module.SampleData.Controllers
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
            var usePostgres = false;
            var sampleContentFolder = Path.Combine(GlobalConfiguration.ContentRootPath, "Modules", "SimplCommerce.Module.SampleData", "SampleContent");

            var filePath = usePostgres ? Path.Combine(sampleContentFolder, "ResetToSampleData_Postgres.sql") : Path.Combine(sampleContentFolder, "ResetToSampleData.sql");
            var lines = System.IO.File.ReadLines(filePath);
            var commands = usePostgres ? sqlRepository.PostgresCommands(lines) : sqlRepository.ParseCommand(lines);
            sqlRepository.RunCommands(commands);

            CopyImages(sampleContentFolder);

            return Redirect("~/");
        }

        private void CopyImages(string sampleContentFolder)
        {
            var imageFolder = Path.Combine(sampleContentFolder, "Images");
            var destDir = Path.Combine(GlobalConfiguration.WebRootPath, "user-content");
            IEnumerable<string> files = Directory.GetFiles(imageFolder);
            foreach (var file in files)
            {
                var destFileName = Path.Combine(destDir, Path.GetFileName(file));
                System.IO.File.Copy(file, destFileName, true);
            }
        }
    }
}
