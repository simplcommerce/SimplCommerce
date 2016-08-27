using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Localization;

namespace SimplCommerce.WebHost
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IList<ModuleInfo> _modules = new List<ModuleInfo>();

        public Startup(IHostingEnvironment env)
        {
            _hostingEnvironment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;
            LoadInstalledModules();

            services.AddDbContext<SimplDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SimplCommerce.WebHost")));

            services.AddIdentity<User, Role>(configure => { configure.Cookies.ApplicationCookie.LoginPath = "/login"; })
                .AddEntityFrameworkStores<SimplDbContext, long>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IStringLocalizerFactory, EfStringLocalizerFactory>();
            services.AddScoped<SignInManager<User>, SimplSignInManager<User>>();

            services.Configure<RazorViewEngineOptions>(
                options => { options.ViewLocationExpanders.Add(new ModuleViewLocationExpander()); });

            var mvcBuilder = services.AddMvc()
                .AddRazorOptions(o =>
                {
                    foreach (var module in _modules)
                    {
                        o.AdditionalCompilationReferences.Add(MetadataReference.CreateFromFile(module.Assembly.Location));
                    }
                })
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            foreach (var module in _modules)
            {
                // Register controller from modules
                mvcBuilder.AddApplicationPart(module.Assembly);

                // Register dependency in modules
                var moduleInitializerType = module.Assembly.GetTypes().FirstOrDefault(x => typeof(IModuleInitializer).IsAssignableFrom(x));
                if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
                {
                    var moduleInitializer = (IModuleInitializer) Activator.CreateInstance(moduleInitializerType);
                    moduleInitializer.Init(services);
                }
            }

            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(RepositoryWithTypedId<,>)).As(typeof(IRepositoryWithTypedId<,>));

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>) c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            foreach (var module in GlobalConfiguration.Modules)
            {
                builder.RegisterAssemblyTypes(module.Assembly).AsImplementedInterfaces();
            }

            builder.RegisterInstance(Configuration);
            builder.RegisterInstance(_hostingEnvironment);
            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("vi-VN")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("vi-VN", "vi-VN"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseStaticFiles();

            // Serving static file for modules
            foreach (var module in _modules)
            {
                var wwwrootDir = new DirectoryInfo(Path.Combine(module.Path, "wwwroot"));
                if (!wwwrootDir.Exists)
                {
                    continue;
                }

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(wwwrootDir.FullName),
                    RequestPath = new PathString("/" + module.ShortName)
                });
            }

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
                routes.Routes.Add(new UrlSlugRoute(routes.DefaultHandler));

                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void LoadInstalledModules()
        {
            var moduleRootFolder = new DirectoryInfo(Path.Combine(_hostingEnvironment.ContentRootPath, "Modules"));
            var moduleFolders = moduleRootFolder.GetDirectories();

            foreach (var moduleFolder in moduleFolders)
            {
                var binFolder = new DirectoryInfo(Path.Combine(moduleFolder.FullName, "bin"));
                if (!binFolder.Exists)
                {
                    continue;
                }

                foreach (var file in binFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
                {
                    Assembly assembly;
                    try
                    {
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file.FullName);
                    }
                    catch (FileLoadException ex)
                    {
                        if (ex.Message == "Assembly with same name is already loaded")
                        {
                            // Get loaded assembly
                            assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));
                        }
                        else
                        {
                            throw;
                        }
                    }

                    if (assembly.FullName.Contains(moduleFolder.Name))
                    {
                        _modules.Add(new ModuleInfo
                        {
                            Name = moduleFolder.Name,
                            Assembly = assembly,
                            Path = moduleFolder.FullName
                        });
                    }
                }
            }

            GlobalConfiguration.Modules = _modules;
        }
    }
}