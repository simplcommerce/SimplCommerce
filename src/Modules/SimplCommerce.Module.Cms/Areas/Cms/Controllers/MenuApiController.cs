using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Cms.ViewModels;

namespace SimplCommerce.Module.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "admin")]
    [Route("api/menus")]
    public class MenuApiController : Controller
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IRepository<MenuItem> _menuItemRepository;

        public MenuApiController(IRepository<Menu> menuRepository, IRepository<MenuItem> menuItemRepository)
        {
            _menuRepository = menuRepository;
            _menuItemRepository = menuItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var menuList = await _menuRepository.Query()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.IsPublished,
                    x.IsSystem
                })
                .ToListAsync();
            return Json(menuList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var menu = await _menuRepository.Query()
                .Include(x => x.MenuItems)
                .ThenInclude(m => m.Entity)
                .FirstOrDefaultAsync(x => x.Id == id);
            if(menu == null)
            {
                return NotFound();
            }

            var model = new MenuForm
            {
                Id = menu.Id,
                Name = menu.Name,
                IsPublished = menu.IsPublished,
                Items = menu.MenuItems.Select(x => new MenuItemForm
                {
                    Id = x.Id,
                    EntityId = x.EntityId,
                    ParentId = x.ParentId,
                    Name = x.Entity == null ? x.Name : x.Entity.Name,
                    CustomLink = x.CustomLink,
                    DisplayOrder = x.DisplayOrder,
                }).OrderBy(x => x.DisplayOrder).ToList()
            };

            return Json(model);
        }

        [HttpPost("{id}/add-items")]
        public async Task<IActionResult> AddItem(long id, [FromBody] IList<MenuItemForm> model)
        {
            if (ModelState.IsValid)
            {
                var menu = await _menuRepository.Query().Include(x => x.MenuItems).FirstOrDefaultAsync(x => x.Id == id);
                if(menu == null)
                {
                    return NotFound();
                }

                var addedMenuItems = new List<MenuItem>();
                foreach (var item in model)
                {
                    var menuItem = new MenuItem
                    {
                        Menu = menu,
                        CustomLink = item.CustomLink,
                        Name = item.Name,
                        EntityId = item.EntityId,
                        ParentId = item.ParentId,
                        DisplayOrder = item.DisplayOrder,
                    };

                    menu.MenuItems.Add(menuItem);
                    addedMenuItems.Add(menuItem);
                }

                await _menuRepository.SaveChangesAsync();
                return Ok(addedMenuItems.Select(x => new MenuItemForm
                {
                    Id = x.Id,
                    EntityId = x.EntityId,
                    Name = x.Name,
                    CustomLink = x.CustomLink
                }));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var menuItem = await _menuItemRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _menuItemRepository.Remove(menuItem);
            await _menuItemRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MenuForm model)
        {
            if (ModelState.IsValid)
            {
                var menu = new Menu
                {
                    Name = model.Name,
                    IsPublished = model.IsPublished
                };

                _menuRepository.Add(menu);
                await _menuRepository.SaveChangesAsync();

                return Json(menu);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] MenuForm model)
        {
            if (ModelState.IsValid)
            {
                var menu = await _menuRepository.Query().Include(x => x.MenuItems).FirstOrDefaultAsync(x => x.Id == id);
                if(menu == null)
                {
                    return NotFound();
                }

                menu.Name = model.Name;
                menu.IsPublished = model.IsPublished;
                foreach(var item in menu.MenuItems)
                {
                    var modelMenuItem = model.Items.FirstOrDefault(x => x.Id == item.Id);
                    if (modelMenuItem == null)
                    {
                        continue;
                    }

                    item.EntityId = modelMenuItem.EntityId;
                    item.Name = modelMenuItem.Name;
                    item.CustomLink = modelMenuItem.CustomLink;
                    item.ParentId = modelMenuItem.ParentId;
                    item.DisplayOrder = modelMenuItem.DisplayOrder;
                }

                var deletedMenuItems = menu.MenuItems.Where(x => !model.Items.Any(m => m.Id == x.Id));
                foreach (var item in deletedMenuItems)
                {
                    _menuItemRepository.Remove(item);
                }

                await _menuRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var menu = await _menuRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            if (menu.IsSystem)
            {
                return BadRequest(new { Error = "A system menu cannot be deleted." });
            }

            _menuRepository.Remove(menu);
            await _menuRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
