using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using System;

namespace SimplCommerce.Module.Localization.Extensions
{
    public static class LocalizationServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedLocalization(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();

            AddLocalizationServices(services);

            return services;
        }

        public static IServiceCollection AddLocalization(
            this IServiceCollection services,
            Action<LocalizationOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            AddLocalizationServices(services, setupAction);

            return services;
        }

        private static void AddLocalizationServices(
            IServiceCollection services,
            Action<LocalizationOptions> setupAction)
        {
            AddLocalizationServices(services);
            services.Configure(setupAction);
        }

        private static void AddLocalizationServices(IServiceCollection services)
        {
            services.TryAddSingleton<IStringLocalizerFactory, EfStringLocalizerFactory>();
            services.TryAddTransient(typeof(IStringLocalizer<>), typeof(EfStringLocalizer<>));
        }
    }
}