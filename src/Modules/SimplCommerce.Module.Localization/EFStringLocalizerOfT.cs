using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Localization.Models;

namespace SimplCommerce.Module.Localization
{
    public class EFStringLocalizer<T> : IStringLocalizer<T>
    {
        private IRepository<Resource> _resourceRepository;

        public EFStringLocalizer(IRepository<Resource> resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _resourceRepository.Query()
              .Include(r => r.Culture)
              .Where(r => r.Culture.Name == CultureInfo.CurrentCulture.Name)
              .Select(r => new LocalizedString(r.Key, r.Value, true));
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new EFStringLocalizer(_resourceRepository);
        }

        private string GetString(string name)
        {
            return _resourceRepository.Query()
                .Include(r => r.Culture)
                .Where(r => r.Culture.Name == CultureInfo.CurrentCulture.Name)
                .FirstOrDefault(r => r.Key == name)?.Value;
        }
    }
}
