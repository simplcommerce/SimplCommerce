using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripeV2.Models;

namespace SimplCommerce.Module.PaymentStripeV2.Extensions
{
    public static class PaymentStripeV2Extensions
    {
        public static List<AdditionalInformation> GetAdditionalInfos(this PaymentAttempt paymentAttempt)
        {
            var list = !string.IsNullOrWhiteSpace(paymentAttempt?.AdditionalInformation)
                ? AdditionalInformation.GetListFromJson(paymentAttempt?.AdditionalInformation)
                : new List<AdditionalInformation>();
            return list;
        }

        public static List<AdditionalInformation> AddInfo(this List<AdditionalInformation> list, string message, [CallerMemberName] string callerMemberName = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return list;
            }

            return list.AddInfo(new AdditionalInformation { Message = message, Component = callerMemberName });
        }

        public static List<AdditionalInformation> AddInfo(this List<AdditionalInformation> list, AdditionalInformation information)
        {
            list.Add(information);
            return list;
        }

        public static string ConvertToJson(this List<AdditionalInformation> list)
        {
            return AdditionalInformation.GetSerialization(list);
        }

        public static void AddInfo(this PaymentAttempt paymentAttempt, string message, [CallerMemberName] string callerMemberName = null)
        {
            paymentAttempt.AdditionalInformation = paymentAttempt.GetAdditionalInfos().AddInfo(message, callerMemberName).ConvertToJson();
        }
    }
}
