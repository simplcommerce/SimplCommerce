using System.Threading.Tasks;

namespace SimplCommerce.Module.Tax.Services
{
    public interface ITaxService
    {
        Task<decimal> GetTaxPercent(long? taxClassId, string countryId, long stateOrProvinceId, string ZipCode);
    }
}
