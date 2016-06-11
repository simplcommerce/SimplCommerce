using SimplCommerce.Core.ApplicationServices;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Web.Areas.Admin.Controllers
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
            mediaService.SaveMedia(file.OpenReadStream(), fileName, file.ContentType);

            return Ok(mediaService.GetMediaUrl(fileName));
        }
    }
}
