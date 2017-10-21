using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Tax.Models
{
    public class TaxRate : EntityBase
    {
        public string Name { get; set; }

        public long TaxClassId { get; set; }

        public TaxClass TaxClass { get; set; }

        public long CountryId { get; set; }

        /// <summary>
        /// 0 for all
        /// </summary>
        public long StateOrProvinceId { get; set; }

        public string ZipCode { get; set; }

        public decimal Rate { get; set; }
    }
}
