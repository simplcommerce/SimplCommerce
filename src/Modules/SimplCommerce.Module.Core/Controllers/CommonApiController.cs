using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/common")]
    public class CommonApiController : Controller
    {
        private readonly IMediaService mediaService;

        public CommonApiController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            mediaService.SaveMedia(file.OpenReadStream(), fileName, file.ContentType);

            return Ok(mediaService.GetMediaUrl(fileName));
        }
    }
}
