using System.Collections.Generic;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;

namespace SimplCommerce.Module.Cms.Areas.Cms.ViewModels
{
    public class SpaceBarWidgetForm : WidgetFormBase
    {
        public IList<SpaceBarWidgetSetting> Items = new List<SpaceBarWidgetSetting>();
    }
}
