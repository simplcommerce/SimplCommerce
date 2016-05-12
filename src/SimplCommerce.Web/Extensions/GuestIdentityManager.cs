using System;
using Microsoft.AspNet.Http;

namespace SimplCommerce.Web.Extensions
{
    public static class GuestIdentityManager
    {
        private const string GuestIdCookieName = "GuestIdCookiesName";

        public static Guid? GetGuestId(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.ContainsKey(GuestIdCookieName))
            {
                return Guid.Parse(httpContext.Request.Cookies[GuestIdCookieName].ToString());
            }

            return null;
        }

        public static Guid GetOrCreateGuestId(HttpContext httpContext)
        {
            var guestId = GetGuestId(httpContext);

            if (guestId.HasValue)
            {
                return guestId.Value;
            }

            guestId = Guid.NewGuid();
            httpContext.Response.Cookies.Append(GuestIdCookieName, guestId.ToString(), new CookieOptions
            {
                Expires = DateTime.MaxValue
            });

            return guestId.Value;
        }
    }
}