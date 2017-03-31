using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Infrastructure.Web.ModelBinders;

namespace SimplCommerce.WebHost.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadInstalledModules(this IServiceCollection services,
            IList<ModuleInfo> modules, IHostingEnvironment hostingEnvironment)
        {
            var moduleRootFolder = new DirectoryInfo(Path.Combine(hostingEnvironment.ContentRootPath, "Modules"));
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
                    catch (FileLoadException)
                    {
                        // Get loaded assembly
                        assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));

                        if (assembly == null)
                        {
                            throw;
                        }
                    }

                    if (assembly.FullName.Contains(moduleFolder.Name))
                    {
                        modules.Add(new ModuleInfo
                        {
                            Name = moduleFolder.Name,
                            Assembly = assembly,
                            Path = moduleFolder.FullName
                        });
                    }
                }
            }

            GlobalConfiguration.Modules = modules;
            return services;
        }
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services, IList<ModuleInfo> modules)
        {
            var mvcBuilder = services
                .AddMvc(o =>
                {
                    o.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider());
                })
                .AddRazorOptions(o =>
                {
                    foreach (var module in modules)
                    {
                        o.AdditionalCompilationReferences.Add(MetadataReference.CreateFromFile(module.Assembly.Location));
                    }
                })
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            foreach (var module in modules)
            {
                // Register controller from modules
                mvcBuilder.AddApplicationPart(module.Assembly);

                // Register dependency in modules
                var moduleInitializerType =
                    module.Assembly.GetTypes().FirstOrDefault(x => typeof(IModuleInitializer).IsAssignableFrom(x));
                if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
                {
                    var moduleInitializer = (IModuleInitializer)Activator.CreateInstance(moduleInitializerType);
                    moduleInitializer.Init(services);
                }
            }

            return services;
        }

        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(configure => { configure.Cookies.ApplicationCookie.LoginPath = "/login"; })
                .AddRoleStore<SimplRoleStore>()
                .AddUserStore<SimplUserStore>()
                .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<SimplDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("SimplCommerce.WebHost")));
            return services;
        }

        public static IServiceProvider Build(this IServiceCollection services,
            IConfigurationRoot configuration, IHostingEnvironment hostingEnvironment)
        {
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
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            foreach (var module in GlobalConfiguration.Modules)
            {
                builder.RegisterAssemblyTypes(module.Assembly).AsImplementedInterfaces();
            }

            builder.RegisterInstance(configuration);
            builder.RegisterInstance(hostingEnvironment);
            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
    }
}