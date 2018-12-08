using System.Collections.Generic;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Localization;

namespace SimplCommerce.Module.Localization.Areas.Localization.ViewModel
{
    public class LanguageSwitcherModel
    {
        public IEnumerable<Culture> Cultures => GlobalConfiguration.Cultures;

        public string CurrentUICulture { get; set; }

        public string UserSelectedCulture { get; set; }
    }
}
