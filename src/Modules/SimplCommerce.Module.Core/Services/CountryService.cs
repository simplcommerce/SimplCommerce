using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task Create(Country country)
        {
            _countryRepository.Add(country);

            await Commit();
        }

        public async Task Delete(Country country)
        {
            //TODO: Implement Non-destrutive delete?
            //country.IsDeleted = true;
            _countryRepository.Remove(country);

            await Commit();
        }

        public async Task Update(Country country)
        {
            await Commit();
        }

        private async Task Commit()
        {
            await _countryRepository.SaveChangesAsync();
        }
    }
}
