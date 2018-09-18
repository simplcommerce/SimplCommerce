using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace SimplCommerce.Infrastructure.Web.ModelBinders
{
	public class InvariantDecimalModelBinderProvider : IModelBinderProvider
	{
		private readonly ILoggerFactory _loggerFactory;

		public InvariantDecimalModelBinderProvider(ILoggerFactory loggerfactory)
		{
			_loggerFactory = loggerfactory;
		}

		public IModelBinder GetBinder(ModelBinderProviderContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (!context.Metadata.IsComplexType && (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?)))
			{
				return new InvariantDecimalModelBinder(context.Metadata.ModelType, _loggerFactory);
			}

			return null;
		}
	}
}
