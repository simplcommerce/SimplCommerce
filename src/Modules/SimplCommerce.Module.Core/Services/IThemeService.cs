using System.Collections.Generic;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Services
{
    public interface IThemeService
    {
        IList<ThemeListItem> GetInstalledThemes();

        void SetCurrentTheme(string themeName);
    }
}
