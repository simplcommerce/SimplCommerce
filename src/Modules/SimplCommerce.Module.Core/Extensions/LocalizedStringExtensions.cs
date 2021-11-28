using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Localization;

namespace SimplCommerce.Module.Core.Extensions
{
    public static class LocalizedStringExtensions
    {
        public static Func<int, LocalizedHtmlString> GetTextPartsFunction(this LocalizedHtmlString localizedHtmlString, params string[] splitTokens)
        {
            var originalTextParts = localizedHtmlString.Name.Split(splitTokens, StringSplitOptions.None).ToList();
            var localizedTextParts = localizedHtmlString.Value.Split(splitTokens, StringSplitOptions.None).ToList();

            LocalizedHtmlString funcLocalizedParts(int i) =>
                i < originalTextParts.Count && i < localizedTextParts.Count
                    ? new LocalizedHtmlString(originalTextParts.ElementAt(i), localizedTextParts.ElementAt(i))
                    : new LocalizedHtmlString($"Index_{i}_OutOfRange", string.Empty);

            return funcLocalizedParts;
        }
    }
}
