using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Tax.Models;

namespace SimplCommerce.Module.Tax.Services
{
    public class TaxService : ITaxService
    {
        private readonly IRepository<TaxRate> _taxRateRepository;

        public TaxService(IRepository<TaxRate> taxRateRepository)
        {
            _taxRateRepository = taxRateRepository;
        }

        public async Task<decimal> GetTaxPercent(long? taxClassId, long countryId, long stateOrProvinceId)
        {
            decimal taxPercent = 0;
            if (taxClassId.HasValue)
            {
                var taxRate = await _taxRateRepository.Query()
                           .Where(x => x.CountryId == countryId
                           && (x.StateOrProvinceId == stateOrProvinceId || x.StateOrProvinceId == null)
                           && x.TaxClassId == taxClassId.Value).FirstOrDefaultAsync();

                if (taxRate != null)
                {
                    taxPercent = taxRate.Rate;
                }
            }

            return taxPercent;
        }
    }
}
