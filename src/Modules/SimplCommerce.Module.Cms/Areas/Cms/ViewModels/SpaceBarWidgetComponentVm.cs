using System.Collections.Generic;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class SpaceBarWidgetComponentVm
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public List<SpaceBarWidgetSetting> Items { get; set; }
    }
}
