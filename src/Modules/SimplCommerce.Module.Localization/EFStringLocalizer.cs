using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace SimplCommerce.Module.Localization
{
    public class EfStringLocalizer : IStringLocalizer
    {
        private readonly IList<ResourceString> _resourceStrings;

        public EfStringLocalizer(IList<ResourceString> resourceStrings)
        {
            _resourceStrings = resourceStrings;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _resourceStrings
                .Where(r => r.Culture == CultureInfo.CurrentCulture.Name)
                .Select(r => new LocalizedString(r.Key, r.Value, true));
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new EfStringLocalizer(_resourceStrings);
        }

        private string GetString(string name)
        {
            return _resourceStrings
                .Where(r => r.Culture == CultureInfo.CurrentCulture.Name)
                .FirstOrDefault(r => r.Key == name)?.Value;
        }
    }
}