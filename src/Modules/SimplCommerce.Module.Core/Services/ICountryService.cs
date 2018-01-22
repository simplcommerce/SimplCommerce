using SimplCommerce.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Core.Services
{
    public interface ICountryService
    {
        Task Create(Country country);

        Task Update(Country country);

        Task Delete(Country country);
    }
}
