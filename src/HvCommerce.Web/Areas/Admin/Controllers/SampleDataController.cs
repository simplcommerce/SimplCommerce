using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Infrastructure.EntityFramework;
using Microsoft.AspNet.Mvc;

namespace HvCommerce.Web.Areas.Admin.Controllers
{
    public class SampleDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetToSample()
        {
            // A temporary (hack) solution because the confict verion ef6-7
            var dbContext = new HvDbContext(GlobalConfiguration.ConnectionString);
            var commands = ReadAllCommands();
            foreach (var command in commands)
            {
                dbContext.Database.ExecuteSqlCommand(command);
            }

            CopyImages();

            return Redirect("~/");
        }

        private void CopyImages()
        {
            var sourceDir = Path.Combine(GlobalConfiguration.ApplicationPath, "SampleData", "ProductImages");
            var destDir = Path.Combine(GlobalConfiguration.ApplicationPath, "UserContents");
            IEnumerable <string> files = Directory.GetFiles(sourceDir);
            foreach (var file in files)
            {
                var destFileName = Path.Combine(destDir, Path.GetFileName(file));
                System.IO.File.Copy(file, destFileName, true);
            }
        }

        private IList<string> ReadAllCommands()
        {
            var filePath = Path.Combine(GlobalConfiguration.ApplicationPath, "SampleData", "ResetToSampleData.sql");
            var lines = System.IO.File.ReadAllLines(filePath);

            var sb = new StringBuilder();
            var commands = new List<string>();
            foreach (var line in lines)
            {
                if (string.Equals(line, "GO", StringComparison.OrdinalIgnoreCase))
                {
                    if (sb.Length > 0)
                    {
                        commands.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        sb.Append(line);
                    }
                }
            }

            return commands;
        }
    }
}