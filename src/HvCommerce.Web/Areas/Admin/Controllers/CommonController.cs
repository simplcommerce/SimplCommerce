using HvCommerce.Core.ApplicationServices;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HvCommerce.Web.Areas.Admin.Controllers
{
    public class CommonController : Controller
    {
        private readonly IMediaService mediaService;

        public CommonController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            mediaService.SaveMedia(file.OpenReadStream(), fileName);

            return Ok(mediaService.GetMediaUrl(fileName));
        }
    }
}
