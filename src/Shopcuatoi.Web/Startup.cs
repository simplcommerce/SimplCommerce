using System;
using System.Data.Entity;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Core.Infrastructure.EntityFramework;
using Shopcuatoi.Infrastructure;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.RouteConfigs;
using Microsoft.AspNet.Authentication.Facebook;
using Microsoft.AspNet.Authentication.Google;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json.Serialization;

namespace Shopcuatoi.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true);

            if (hostingEnvironment.IsDevelopment())
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
            GlobalConfiguration.ConnectionString = Configuration["Data:DefaultConnection:ConnectionString"];
            GlobalConfiguration.ApplicationPath = hostingEnvironment.WebRootPath;

            services.AddIdentity<User, Role>(configure =>
            {
                configure.User.RequireUniqueEmail = true;
                configure.Password.RequiredLength = 8;
                //define the default page if a call must be [Autorized]
                configure.Cookies.ApplicationCookie.LoginPath = "/login";
            })
                .AddRoleStore<HvRoleStore>()
                .AddUserStore<HvUserStore>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddJsonOptions(
                    options =>
                    {
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    });

            services.AddScoped(f => Configuration);

            GlobalConfiguration.Modules.Add(new HvModule { Name = "Core", AssemblyName = "Shopcuatoi.Core" });
            GlobalConfiguration.Modules.Add(new HvModule { Name = "Orders", AssemblyName = "Shopcuatoi.Orders" });

            services.AddScoped<DbContext, HvDbContext>(f => new HvDbContext(GlobalConfiguration.ConnectionString));

            // TODO: break down to new method in new class
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>));
            builder.RegisterGeneric(typeof (RepositoryWithTypedId<,>)).As(typeof (IRepositoryWithTypedId<,>));
            foreach (var module in GlobalConfiguration.Modules)
            {
                builder.RegisterAssemblyTypes(Assembly.Load(module.AssemblyName)).AsImplementedInterfaces();
            }

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
                })
                .UseFacebookAuthentication(new FacebookOptions
                {
                    AppId = "1716532045292977",
                    AppSecret = "dfece01ae919b7b8af23f962a1f87f95"
                });

            app.UseMvc(routes =>
            {
                routes.Routes.Add(new GenericRule(routes.DefaultHandler));

                routes.MapRoute(
                    "areaRoute",
                    "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}