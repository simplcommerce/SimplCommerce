using System;
using Microsoft.AspNet.Http;

namespace Shopcuatoi.Web.Extensions
{
    public static class GuestIdentityManager
    {
        private const string GuestIdCookieName = "GuestIdCookiesName";

        public static Guid GetGuestId(HttpContext httpContext)
        {
            if (!httpContext.Request.Cookies.ContainsKey(GuestIdCookieName))
            {
                var guestId = Guid.NewGuid();
                httpContext.Response.Cookies.Append(GuestIdCookieName, guestId.ToString(), new CookieOptions
                {
                    Expires = DateTime.MaxValue
                });
                return guestId;
            }
            return Guid.Parse(httpContext.Request.Cookies[GuestIdCookieName].ToString());
        }
    }
}