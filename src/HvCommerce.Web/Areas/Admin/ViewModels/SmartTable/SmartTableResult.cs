using System.Collections.Generic;

namespace HvCommerce.Web.Areas.Admin.ViewModels.SmartTable
{
    public class SmartTableResult<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalRecord { get; set; }
    }
}
