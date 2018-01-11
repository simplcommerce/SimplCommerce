using System;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure;
using System.Collections.Generic;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.ViewModels;
using SimplCommerce.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Module.Core.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IRepository<AppSetting> _appSettingRepository;
        private string _currentThemeName;

        public ThemeService(IConfiguration configuration, IRepository<AppSetting> appSettingRepository)
        {
            _configurationRoot = (IConfigurationRoot)configuration;
            _appSettingRepository = appSettingRepository;
            _currentThemeName = configuration[SimplConstants.ThemeConfigKey];
        }

        public async Task<IList<ThemeListItem>> GetInstalledThemes()
        {
            IList<ThemeListItem> themes = new List<ThemeListItem>
            {
                new ThemeListItem
                {
                    Name = "Generic",
                    DisplayName = "Generic",
                    IsCurrent = "Generic" == _currentThemeName,
                    ThumbnailUrl = "/themes/generic-theme.png"
                }
            };

            var themeRootFolder = new DirectoryInfo(Path.Combine(GlobalConfiguration.ContentRootPath, "Themes"));
            var themeFolders = themeRootFolder.GetDirectories();

            foreach (var themeFolder in themeFolders)
            {
                var themeJsonPath = Path.Combine(themeFolder.FullName, "theme.json");
                if (!File.Exists(themeJsonPath))
                {
                    throw new ApplicationException($"Cannot found theme.json for theme {themeFolder.Name}");
                }

                var manifestStr = await File.ReadAllTextAsync(themeJsonPath);
                ThemeManifest themeManifest;
                themeManifest = JsonConvert.DeserializeObject<ThemeManifest>(manifestStr);
                var theme = new ThemeListItem
                {
                    Name = themeManifest.Name,
                    DisplayName = themeManifest.DisplayName,
                    IsCurrent = themeManifest.Name == _currentThemeName,
                    ThumbnailUrl = $"/themes/{themeManifest.Name}/{themeManifest.Name}.png"
                };

                themes.Add(theme);
            }

            return themes;
        }

        public async Task SetCurrentTheme(string themeName)
        {
            var themeSetting = await _appSettingRepository.Query().Where(x => x.Key == SimplConstants.ThemeConfigKey).FirstAsync();
            themeSetting.Value = themeName;
            await _appSettingRepository.SaveChangesAsync();
            _configurationRoot.Reload();
        }
    }
}
