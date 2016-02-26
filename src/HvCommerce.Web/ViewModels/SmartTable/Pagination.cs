using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HvCommerce.Web.ViewModels.SmartTable
{
    public class Pagination
    {
        public int Start { get; set; }

        public int TotalItemCount { get; set; }

        public int Number { get; set; }

        public int NumberOfPages { get; set; }
    }
}
