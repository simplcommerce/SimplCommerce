using SimplCommerce.Module.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class HomeProductWidgetSetting 
    {
        public HomeProductWidgetSetting()
        {
            ProductIds = new List<Pname>();
        }
        public int NumberofProducts { get; set; }
        public List<Pname> ProductIds { get; set; } 
    }
    public class Pname {
        public string ProductId { get; set; }
    }
}
