using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimplCommerce.Infrastructure
{
    public class AnnotationValidationException : Exception
    {
        public AnnotationValidationException()
        {
        }

        public AnnotationValidationException(string message) : base(message)
        {
        }

        public AnnotationValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AnnotationValidationException(Type target, IList<ValidationResult> validationResults)
        {
            TargetType = target;
            ValidationResults = validationResults;
        }

        public IList<ValidationResult> ValidationResults { get; }

        public Type TargetType { get; }

        public override string Message
        {
            get
            {
                return string.Concat(TargetType.ToString(), ": ", string.Join(';', ValidationResults.Select(x => $"{x.ErrorMessage}")));
            }
        }
    }
}
