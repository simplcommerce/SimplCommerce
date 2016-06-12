using System;
using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Core.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Web.Extensions
{
    public class WorkContext : IWorkContext
    {
        private const string UserGuidCookiesName = "SimplUserGuid";
        private const long GuestRoleId = 3;

        private User _currentUser;
        private UserManager<User> _userManager;
        private HttpContext _httpContext;
        private IRepository<User> _userRepository;

        public WorkContext(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IRepository<User> userRepository)
        {
            _userManager = userManager;
            _httpContext = contextAccessor.HttpContext;
            _userRepository = userRepository;
        }

        public async Task<User> GetCurrentUser()
        {
            if(_currentUser != null)
            {
                return _currentUser;
            }

            // On external login callback Identity.IsAuthenticated = true. But it's an external claim principal
            // Login by google, get _userManager.GetUserAsync from ClaimsPrincipal throw exception becasue the UserIdClaimType has value but too big.
            if (_httpContext.User.Identity.AuthenticationType == "Identity.Application")
            {
                var contextUser = _httpContext.User;
                _currentUser = await _userManager.GetUserAsync(contextUser);
            }

            if(_currentUser != null)
            {
                return _currentUser;
            }

            var userGuid = GetUserGuidFromCookies();
            if(userGuid.HasValue)
            {
                _currentUser = _userRepository.Query().Include(x => x.Roles).FirstOrDefault(x => x.UserGuid == userGuid);
            }

            if (_currentUser != null && _currentUser.Roles.Count == 1 && _currentUser.Roles.First().RoleId == GuestRoleId)
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
                UserName = dummyEmail
            };
            var abc =  await _userManager.CreateAsync(_currentUser, "1qazZAQ!");
            await _userManager.AddToRoleAsync(_currentUser, "guest");
            SetUserGuidCookies(_currentUser.UserGuid);
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

        private void SetUserGuidCookies(Guid userGuid)
        {
            _httpContext.Response.Cookies.Append(UserGuidCookiesName, _currentUser.UserGuid.ToString(), new CookieOptions
            {
                Expires = DateTime.UtcNow.AddYears(5),
                HttpOnly = true
            });
        }
    }
}
