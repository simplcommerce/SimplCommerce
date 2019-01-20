using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class AppSetting : EntityBaseWithTypedId<string>
    {
        public AppSetting(string id)
        {
            Id = id;
        }

        [StringLength(450)]
        public string Value { get; set; }

        [StringLength(450)]
        public string Module { get; set; }

        public bool IsVisibleInCommonSettingPage { get; set; }
    }
}
