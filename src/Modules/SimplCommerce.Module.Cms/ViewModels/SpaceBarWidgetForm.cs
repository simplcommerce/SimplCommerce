using System.Collections.Generic;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class SpaceBarWidgetForm : WidgetFormBase
    {
        public IList<SpaceBarWidgetSetting> Items = new List<SpaceBarWidgetSetting>();
    }
}
