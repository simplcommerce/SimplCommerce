using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Extensions
{
    public class WorkContext : IWorkContext
    {
        private const string UserGuidCookiesName = "SimplUserGuid";
        private const long GuestRoleId = 3;
        private readonly IConfiguration _configuration;

        private User _currentUser;
        private readonly HttpContext _httpContext;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<User> _userRepository;

        public WorkContext(UserManager<User> userManager,
            IHttpContextAccessor contextAccessor,
            IRepository<User> userRepository,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _httpContext = contextAccessor.HttpContext;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<User> GetCurrentUser()
        {
            if (_currentUser != null)
            {
                return _currentUser;
            }

            var contextUser = _httpContext.User;
            _currentUser = await _userManager.GetUserAsync(contextUser);

            if (_currentUser != null)
            {
                return _currentUser;
            }

            var userGuid = GetUserGuidFromCookies();
            if (userGuid.HasValue)
            {
                _currentUser = _userRepository.Query().Include(x => x.Roles)
                    .FirstOrDefault(x => x.UserGuid == userGuid);
            }

            if (_currentUser != null && _currentUser.Roles.Count == 1 &&
                _currentUser.Roles.First().RoleId == GuestRoleId)
            {
                return _currentUser;
            }

            userGuid = Guid.NewGuid();
            var dummyEmail = string.Format("{0}@guest.simplcommerce.com", userGuid);
            _currentUser = new User
            {
                FullName = "Guest",
                UserGuid = userGuid.Value,
                Email = dummyEmail,
                UserName = dummyEmail,
                Culture = _configuration.GetValue<string>("Global.DefaultCultureUI") ??
                          GlobalConfiguration.DefaultCulture
            };
            var abc = await _userManager.CreateAsync(_currentUser, "1qazZAQ!");
            await _userManager.AddToRoleAsync(_currentUser, "guest");
            SetUserGuidCookies();
            return _currentUser;
        }

        private Guid? GetUserGuidFromCookies()
        {
            if (_httpContext.Request.Cookies.ContainsKey(UserGuidCookiesName))
            {
                return Guid.Parse(_httpContext.Request.Cookies[UserGuidCookiesName]);
            }

            return null;
        }

        private void SetUserGuidCookies()
        {
            _httpContext.Response.Cookies.Append(UserGuidCookiesName, _currentUser.UserGuid.ToString(),
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(5),
                    HttpOnly = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.Strict
                });
        }
    }
}
