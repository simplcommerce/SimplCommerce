using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.Core.Extensions.TagHelpers
{
    [HtmlTargetElement(Attributes = AppendVersionAttributeName)]
    public class AppendVersionTagHelper : TagHelper
    {
        private const string AppendVersionAttributeName = "simpl-append-version";
        private readonly IConfiguration _config;

        public AppendVersionTagHelper(IConfiguration config)
        {
            _config = config;
        }

        [HtmlAttributeName(AppendVersionAttributeName)]
        public bool AppendVersion { get; set; }

        public override int Order => int.MinValue;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll(AppendVersionAttributeName);

            if (!AppendVersion)
            {
                return;
            }

            if (output.Attributes.ContainsName("href"))
            {
                var href = output.Attributes["href"].Value.ToString();
                output.Attributes.SetAttribute("href", AppendVersionToUrl(href));
            }

            if (output.Attributes.ContainsName("src"))
            {
                var src = output.Attributes["src"].Value.ToString();
                output.Attributes.SetAttribute("src", AppendVersionToUrl(src));
            }
        }

        private string AppendVersionToUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            var version = _config["Global.AssetVersion"];

            return url.Contains("?") ? $"{url}&v={version}" : $"{url}?v={version}";
        }
    }
}