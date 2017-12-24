namespace Iyzpay.NetCore
{
    internal class RequestFormatter
    {
        public static string FormatPrice(string price)
        {
            if (!price.Contains("."))
                return price + ".0";
            var subStrIndex = 0;
            var priceReversed = StringHelper.Reverse(price);
            for (var i = 0; i < priceReversed.Length; i++)
                if (priceReversed[i].Equals('0'))
                {
                    subStrIndex = i + 1;
                }
                else if (priceReversed[i].Equals('.'))
                {
                    priceReversed = "0" + priceReversed;
                    break;
                }
                else
                {
                    break;
                }
            return StringHelper.Reverse(priceReversed.Substring(subStrIndex));
        }
    }
}