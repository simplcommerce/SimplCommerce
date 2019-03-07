using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Tax.Models
{
    public class TaxRate : EntityBase
    {
        public long TaxClassId { get; set; }

        public TaxClass TaxClass { get; set; }

        [StringLength(450)]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public long? StateOrProvinceId { get; set; }

        public StateOrProvince StateOrProvince { get; set; }

        public decimal Rate { get; set; }

        [StringLength(450)]
        public string ZipCode { get; set; }
    }
}
