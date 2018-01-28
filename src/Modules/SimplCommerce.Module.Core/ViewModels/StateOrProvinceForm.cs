using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Core.ViewModels
{
    public class StateOrProvinceForm
    {
        public long Id { get; set; }

        public long CountryId { get; set; }

        public string CountryCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
