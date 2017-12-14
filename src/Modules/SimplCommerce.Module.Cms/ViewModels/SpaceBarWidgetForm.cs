using SimplCommerce.Module.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class SpaceBarWidgetForm : WidgetFormBase
    {
        public IList<SpaceBarWidgetSetting> Items = new List<SpaceBarWidgetSetting>();
    }
}
