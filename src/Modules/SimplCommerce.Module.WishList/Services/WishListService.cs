using System;
using System.Security.Cryptography;
using System.Text;

namespace SimplCommerce.Module.WishList.Services
{
    public class WishListService : IWishListService
    {
        public string GenerateSharingCode(long wishListId)
        {
            var rnd = new Random();
            var randomNumber = rnd.Next(1, 1000);
            var input = wishListId.ToString() + DateTime.Now + randomNumber;

            using (var shaHash = SHA256.Create())
            {
                var data = shaHash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                for (var i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                var sharingCode = sBuilder.ToString();

                return sharingCode;
            }
        }
    }
}
