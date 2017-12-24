using System;
using System.Net;

namespace Iyzpay.NetCore
{
    public class IyzipayResource
    {
        private static readonly string AUTHORIZATION = "Authorization";
        private static readonly string RANDOM_HEADER_NAME = "x-iyzi-rnd";
        private static readonly string CLIENT_VERSION = "x-iyzi-client-version";
        private static readonly string IYZIWS_HEADER_NAME = "IYZWS ";
        private static readonly string COLON = ":";

        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorGroup { get; set; }
        public string Locale { get; set; }
        public long SystemTime { get; set; }
        public string ConversationId { get; set; }

        protected static WebHeaderCollection GetHttpHeaders(BaseRequest request, Options options)
        {
            var randomString = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
            var headers = new WebHeaderCollection();
            headers.Add("Accept", "application/json");
            headers.Add(RANDOM_HEADER_NAME, randomString);
            headers.Add(CLIENT_VERSION, "iyzipay-dotnet-2.1.13");
            headers.Add(AUTHORIZATION, PrepareAuthorizationString(request, randomString, options));
            return headers;
        }

        private static string PrepareAuthorizationString(BaseRequest request, string randomString, Options options)
        {
            var hash = HashGenerator.GenerateHash(options.ApiKey, options.SecretKey, randomString, request);
            return IYZIWS_HEADER_NAME + options.ApiKey + COLON + hash;
        }
    }
}