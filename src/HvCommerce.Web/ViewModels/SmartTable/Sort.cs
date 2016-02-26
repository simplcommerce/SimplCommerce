using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HvCommerce.Web.ViewModels.SmartTable
{
    public class Sort
    {
        public string Predicate { get; set; }

        public bool Reverse { get; set; }
    }
}
