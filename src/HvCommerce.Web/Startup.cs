using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework;
using HvCommerce.Infrastructure;
using HvCommerce.Infrastructure.Domain.IRepositories;
using Microsoft.AspNet.Authentication.Google;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Practices.ServiceLocation;

namespace HvCommerce.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            HvConnectionString.Value = Configuration["Data:DefaultConnection:ConnectionString"];
            services.AddIdentity<User, Role>()
                .AddRoleStore<HvRoleStore>()
                .AddUserStore<HvUserStore>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddScoped(f => Configuration);

            services.AddScoped<HvDbContext, HvDbContext>(f => { return new HvDbContext(HvConnectionString.Value); });

            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>));
            builder.RegisterGeneric(typeof (RepositoryWithTypedId<,>)).As(typeof (IRepositoryWithTypedId<,>));

            builder.RegisterAssemblyTypes(Assembly.Load("HvCommerce.Core")).AsImplementedInterfaces();
            builder.Populate(services);
            var container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocatorAdapter(container));
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler(options => { options.AuthenticationDescriptions.Clear(); });

            app.UseStaticFiles();

            app.UseIdentity()
                .UseGoogleAuthentication(new GoogleOptions
                {
                    ClientId = "583825788849-8g42lum4trd5g3319go0iqt6pn30gqlq.apps.googleusercontent.com",
                    ClientSecret = "X8xIiuNEUjEYfiEfiNrWOfI4"
                });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "areaRoute",
                    "{area:exists}/{controller}/{action}",
                    new { controller = "Home", action = "Index" });

                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}