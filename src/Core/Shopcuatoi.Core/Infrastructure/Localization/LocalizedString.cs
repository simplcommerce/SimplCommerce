using System.Globalization;

namespace Shopcuatoi.Core.Infrastructure.Localization
{
    public class LocalizedString
    {
        private static ResourceProviderBase resourceProvider = new DbResourceProvider();


        /// <summary>Password</summary>
        public static string Common_Password
        {
            get
            {
                return resourceProvider.GetResource("Common_Password", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Home Page</summary>
        public static string HomePage
        {
            get
            {
                return resourceProvider.GetResource("HomePage", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Administration</summary>
        public static string Administration
        {
            get
            {
                return resourceProvider.GetResource("Administration", CultureInfo.CurrentUICulture.Name);
            }
        }
    }
}
