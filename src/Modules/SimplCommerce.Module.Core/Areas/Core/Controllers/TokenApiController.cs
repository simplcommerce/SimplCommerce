using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Core.Controllers
{
    [Area("Core")]
    [ApiController]
    public class TokenApiController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public TokenApiController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("/api/token/create")]
        public async Task<IActionResult> CreateToken([FromBody]TokenLoginModel login, bool includeRefreshToken)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
            {
                return BadRequest(new { Error = "Invalid username or password" });
            }

            var claims = await BuildClaims(user);
            var token = _tokenService.GenerateAccessToken(claims);
            if (includeRefreshToken)
            {
                var refreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshTokenHash = _userManager.PasswordHasher.HashPassword(user, refreshToken);
                await _userManager.UpdateAsync(user);
                return Ok(new { token = token, refreshToken = refreshToken});
            }

            return Ok(new { token = token });
        }

        [AllowAnonymous]
        [HttpPost("/api/token/refresh")]
        public async Task<IActionResult> RefeshToken(RefreshTokenModel model)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(model.Token);
            if(principal == null)
            {
                return BadRequest(new { Error = "Invalid token" });
            }

            var user = await _userManager.GetUserAsync(principal);
            var verifyRefreshTokenResult =_userManager.PasswordHasher.VerifyHashedPassword(user, user.RefreshTokenHash, model.RefreshToken);
            if(verifyRefreshTokenResult == PasswordVerificationResult.Success)
            {
                var claims = await BuildClaims(user);
                var newToken = _tokenService.GenerateAccessToken(claims);
                return Ok(new { token = newToken });
            }

            return Forbid();
        }

        private async Task<IList<Claim>> BuildClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return claims;
        }

        public class TokenLoginModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class RefreshTokenModel
        {
            [Required]
            public string Token { get; set; }

            [Required]
            public string RefreshToken { get; set; }
        }
    }
}
