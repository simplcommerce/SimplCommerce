using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SimplCommerce.Module.Cms.Areas.Cms.ViewModels
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
