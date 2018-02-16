using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class SpaceBarWidgetSetting
    {
        public string IconHtml { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string ImageUrl { get; set; }

        [JsonIgnore]
        public IFormFile UploadImage { get; set; }
    }
}
