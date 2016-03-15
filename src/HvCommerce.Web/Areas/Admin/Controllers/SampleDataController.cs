using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Infrastructure.EntityFramework;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            var filePath = Path.Combine(GlobalConfiguration.ApplicationPath, "SampleData", "ResetToSampleData.sql");
            var sql = System.IO.File.ReadAllText(filePath);
            var dbContext = new HvDbContext(GlobalConfiguration.ConnectionString);
            dbContext.Database.ExecuteSqlCommand(sql);
            return Redirect("~/");
        }
    }
}
