using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Core.Models
{
    [Serializable]
    public class ValidationException : Exception
    {
        public string FieldName { get; }

        public ValidationException()
        {
        }

        public ValidationException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }

        public ValidationException(Exception innerException) : base(string.Empty, innerException)
        {
        }

        public ValidationException(string fieldName, string message, Exception innerException) : base(message, innerException)
        {
            FieldName = fieldName;
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
