using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Core;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Notifications.Data;
using SimplCommerce.Module.Notifications.Events;
using SimplCommerce.Module.Notifications.Jobs;
using SimplCommerce.Module.Notifications.Notifiers;
using SimplCommerce.Module.Notifications.Services;
using SimplCommerce.Module.SignalR.RealTime;

namespace SimplCommerce.Module.Notifications
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationRepository, NotificationRepository>();

            services.AddSingleton<INotificationDefinitionManager, NotificationDefinitionManager>();
            services.AddSingleton<IOnlineClientManager, OnlineClientManager>();
            services.AddSingleton<IRealTimeNotifier, SignalRRealTimeNotifier>();

            services.AddTransient<INotificationDistributer, NotificationDistributer>();
            services.AddTransient<INotificationPublisher, NotificationPublisher>();
            services.AddTransient<INotificationSubscriptionManager, NotificationSubscriptionManager>();
            services.AddTransient<IUserNotificationManager, UserNotificationManager>();

            services.AddTransient<ITestNotifier, TestNotifier>();
            services.AddTransient<INotificationHandler<UserSignedIn>, UserSignedInHandler>();
            services.AddTransient<NotificationDistributionJob>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.AddSettingDefinitionItems(SettingDefinitions.DefaultItems());
            app.AddNotificationDefinitionItems(NotificationDefinitions.DefaultItems());
        }
    }
}
