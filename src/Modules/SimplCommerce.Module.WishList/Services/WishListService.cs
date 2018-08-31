using System;
using System.Security.Cryptography;
using System.Text;

namespace SimplCommerce.Module.WishList.Services
{
    public class WishListService : IWishListService
    {
        public string GenerateSharingCode(long wishListId)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 1000);
            string input = wishListId.ToString() + DateTime.Now + randomNumber.ToString();

            using (SHA256 shaHash = SHA256.Create())
            {
                byte[] data = shaHash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                string sharingCode = sBuilder.ToString();

                return sharingCode;
            }
        }
    }
}
