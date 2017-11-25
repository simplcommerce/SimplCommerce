using System.Threading.Tasks;

namespace SimplCommerce.Module.Tax.Services
{
    public interface ITaxService
    {
        Task<decimal> GetTaxPercent(long? taxClassId, long countryId, long stateOrProvinceId);
    }
}
