using System.Collections.Generic;
using System.Linq;

namespace Iyzpay.NetCore
{
    public class ToStringRequestBuilder
    {
        private string _requestString;

        private ToStringRequestBuilder(string requestString)
        {
            _requestString = requestString;
        }

        public static ToStringRequestBuilder NewInstance()
        {
            return new ToStringRequestBuilder("");
        }

        public static ToStringRequestBuilder NewInstance(string requestString)
        {
            return new ToStringRequestBuilder(requestString);
        }

        public ToStringRequestBuilder AppendSuper(string superRequestString)
        {
            if (superRequestString != null)
            {
                superRequestString = superRequestString.Substring(1);
                superRequestString = superRequestString.Substring(0, superRequestString.Length - 1);

                if (superRequestString.Length > 0)
                    _requestString = _requestString + superRequestString + ",";
            }
            return this;
        }

        public ToStringRequestBuilder Append(string key, object value = null)
        {
            if (value != null)
                if (value is IRequestStringConvertible convertible)
                    AppendKeyValue(key, convertible.ToPkiRequestString());
                else
                    AppendKeyValue(key, value.ToString());
            return this;
        }

        public ToStringRequestBuilder AppendPrice(string key, string value)
        {
            if (value != null)
                AppendKeyValue(key, RequestFormatter.FormatPrice(value));
            return this;
        }

        public ToStringRequestBuilder AppendList<T>(string key, List<T> list = null) where T : IRequestStringConvertible
        {
            if (list == null) return this;
            var appendedValue = list.Aggregate("", (current, value) => current + value.ToPkiRequestString() + ", ");
            AppendKeyValueArray(key, appendedValue);
            return this;
        }

        public ToStringRequestBuilder AppendList(string key, List<int> list = null)
        {
            if (list != null)
            {
                var appendedValue = "";
                foreach (var value in list)
                    appendedValue = appendedValue + value + ", ";
                AppendKeyValueArray(key, appendedValue);
            }
            return this;
        }

        private ToStringRequestBuilder AppendKeyValue(string key, string value)
        {
            if (value != null)
                _requestString = _requestString + key + "=" + value + ",";
            return this;
        }

        private ToStringRequestBuilder AppendKeyValueArray(string key, string value)
        {
            if (value != null)
            {
                value = value.Substring(0, value.Length - 2);
                _requestString = _requestString + key + "=[" + value + "],";
            }
            return this;
        }

        private ToStringRequestBuilder AppendPrefix()
        {
            _requestString = "[" + _requestString + "]";
            return this;
        }

        private ToStringRequestBuilder RemoveTrailingComma()
        {
            if (!string.IsNullOrEmpty(_requestString))
                _requestString = _requestString.Substring(0, _requestString.Length - 1);
            return this;
        }

        public string GetRequestString()
        {
            RemoveTrailingComma();
            AppendPrefix();
            return _requestString;
        }
    }
}