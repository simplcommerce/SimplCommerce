using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Cms.Areas.Cms.ViewModels;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Areas.Cms.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IContentLocalizationService _contentLocalizationService;
        private readonly IStringLocalizer _localizer;

        public MenuViewComponent(IRepository<Menu> menuRepository, IContentLocalizationService contentLocalizationService, IStringLocalizerFactory stringLocalizerFactory)
        {
            _menuRepository = menuRepository;
            _contentLocalizationService = contentLocalizationService;
            _localizer = stringLocalizerFactory.Create(null);
        }

        public async Task<IViewComponentResult> InvokeAsync(long menuId)
        {
            var menu = await _menuRepository.Query().Include(x => x.MenuItems).ThenInclude(m => m.Entity).FirstOrDefaultAsync(x => x.Id == menuId);
            if(menu == null)
            {
                throw new ArgumentException($"Cannot found menu item id {menuId}");
            }

            var menuItemVms = new List<MenuItemVm>();
            var menuItems = menu.MenuItems.Where(x => !x.ParentId.HasValue).OrderBy(x => x.DisplayOrder);

            var menuItemEntityTypes = menu.MenuItems.Where(x => x?.Entity?.EntityTypeId != null).Select(x => x.Entity.EntityTypeId).Distinct();
            var menuItemEntityTypeTranslations = menuItemEntityTypes.ToDictionary(k => k, v => _contentLocalizationService.GetLocalizationFunction(entityType: v));

            foreach (var item in menuItems)
            {
                var menuItemVm = Map(item, menuItemEntityTypeTranslations);
                menuItemVms.Add(menuItemVm);
            }

            return View(this.GetViewPath(), menuItemVms);
        }

        private MenuItemVm Map(MenuItem menuItem, Dictionary<string, Func<long, string, string, string>> menuItemEntityTypeTranslations)
        {
            var menuItemName = menuItem.Entity == null
                                ? _localizer.GetString(menuItem.Name)
                                : menuItemEntityTypeTranslations[menuItem.Entity.EntityTypeId](menuItem.Entity.EntityId, nameof(menuItem.Entity.Name), menuItem.Entity.Name);

            var menuItemVm = new MenuItemVm
            {
                Id = menuItem.Id,
                Name = menuItemName,
                Link = menuItem.Entity == null ? menuItem.CustomLink : $"/{menuItem.Entity.Slug}"
            };

            var childItems = menuItem.Children.OrderBy(x => x.DisplayOrder);
            foreach (var childItem in childItems)
            {
                var childMenuItemVm = Map(childItem, menuItemEntityTypeTranslations);
                menuItemVm.AddChildItem(childMenuItemVm);
            }

            return menuItemVm;
        }
    }
}
