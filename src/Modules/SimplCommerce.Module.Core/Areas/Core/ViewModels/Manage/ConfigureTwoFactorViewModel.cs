using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels.Manage
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
