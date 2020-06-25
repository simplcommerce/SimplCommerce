using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Infrastructure.Web.ModelBinders;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.WebHost.IdentityServer;
using System.IdentityModel.Tokens.Jwt;

namespace SimplCommerce.WebHost.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static readonly IModuleConfigurationManager _modulesConfig = new ModuleConfigurationManager();

        public static IServiceCollection AddModules(this IServiceCollection services)
        {
            foreach (var module in _modulesConfig.GetModules())
            {
                if(!module.IsBundledWithHost)
                {
                    TryLoadModuleAssembly(module.Id, module);
                    if (module.Assembly == null)
                    {
                        throw new Exception($"Cannot find main assembly for module {module.Id}");
                    }
                }
                else
                {
                    module.Assembly = Assembly.Load(new AssemblyName(module.Id));
                }

                GlobalConfiguration.Modules.Add(module);
            }

            return services;
        }

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services, IList<ModuleInfo> modules)
        {
            var mvcBuilder = services
                .AddMvc(o =>
                {
                    o.EnableEndpointRouting = false;
                    o.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider());
                })
                .AddRazorRuntimeCompilation()
                .AddViewLocalization()
                .AddModelBindingMessagesLocalizer(services)
                .AddDataAnnotationsLocalization(o =>
                {
                    var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    var L = factory.Create(null);
                    o.DataAnnotationLocalizerProvider = (t, f) => L;
                })
                .AddNewtonsoftJson();

            foreach (var module in modules.Where(x => !x.IsBundledWithHost))
            {
                AddApplicationPart(mvcBuilder, module.Assembly);
            }

            return services;
        }

        /// <summary>
        /// Localize ModelBinding messages, e.g. when user enters string value instead of number...
        /// these messages can't be localized like data attributes
        /// </summary>
        /// <param name="mvc"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IMvcBuilder AddModelBindingMessagesLocalizer
            (this IMvcBuilder mvc, IServiceCollection services)
        {
            return mvc.AddMvcOptions(o =>
            {                
                var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                var L = factory.Create(null);

                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => L["The value '{0}' is invalid.", x]);
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor((x) => L["The field {0} must be a number.", x]);
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor((x) => L["A value for the '{0}' property was not provided.", x]);
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => L["The value '{0}' is not valid for {1}.", x, y]);
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => L["A value is required."]);
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => L["A non-empty request body is required."]);
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => L["The value '{0}' is not valid.", x]);
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => L["The value provided is invalid."]);
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => L["The field must be a number."]);
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => L["The supplied value is invalid for {0}.", x]);
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((x) => L["Null value is invalid."]);
            });
        }

        private static void AddApplicationPart(IMvcBuilder mvcBuilder, Assembly assembly)
        {
            var partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);
            foreach (var part in partFactory.GetApplicationParts(assembly))
            {
                mvcBuilder.PartManager.ApplicationParts.Add(part);
            }

            var relatedAssemblies = RelatedAssemblyAttribute.GetRelatedAssemblies(assembly, throwOnError: false);
            foreach (var relatedAssembly in relatedAssemblies)
            {
                partFactory = ApplicationPartFactory.GetApplicationPartFactory(relatedAssembly);
                foreach (var part in partFactory.GetApplicationParts(relatedAssembly))
                {
                    mvcBuilder.PartManager.ApplicationParts.Add(part);
                }
            }
        }

        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.ClaimsIdentity.UserNameClaimType = JwtRegisteredClaimNames.Sub;
                })
                .AddRoleStore<SimplRoleStore>()
                .AddUserStore<SimplUserStore>()
                .AddSignInManager<SimplSignInManager<User>>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer(options =>
                 {
                     options.Events.RaiseErrorEvents = true;
                     options.Events.RaiseInformationEvents = true;
                     options.Events.RaiseFailureEvents = true;
                     options.Events.RaiseSuccessEvents = true;
                 })
                 .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                 .AddInMemoryApiResources(IdentityServerConfig.Apis)
                 .AddInMemoryClients(IdentityServerConfig.Clients)
                 .AddAspNetIdentity<User>()
                 .AddProfileService<SimplProfileService>()
                 .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material somewhere secure

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                .AddFacebook(x =>
                {
                    x.AppId = configuration["Authentication:Facebook:AppId"];
                    x.AppSecret = configuration["Authentication:Facebook:AppSecret"];

                    x.Events = new OAuthEvents
                    {
                        OnRemoteFailure = ctx => HandleRemoteLoginFailure(ctx)
                    };
                })
                .AddGoogle(x =>
                {
                    x.ClientId = configuration["Authentication:Google:ClientId"];
                    x.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                    x.Events = new OAuthEvents
                    {
                        OnRemoteFailure = ctx => HandleRemoteLoginFailure(ctx)
                    };
                })
                .AddLocalApi(JwtBearerDefaults.AuthenticationScheme, option => {
                    option.ExpectedScope = "api.simplcommerce";
                });

            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new PathString("/login");
                x.Events.OnRedirectToLogin = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase) && context.Response.StatusCode == (int)HttpStatusCode.OK)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return Task.CompletedTask;
                    }

                    context.Response.Redirect(context.RedirectUri);
                    return Task.CompletedTask;
                };
                x.Events.OnRedirectToAccessDenied = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase) && context.Response.StatusCode == (int)HttpStatusCode.OK)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        return Task.CompletedTask;
                    }

                    context.Response.Redirect(context.RedirectUri);
                    return Task.CompletedTask;
                };
            });
            return services;
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<SimplDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("SimplCommerce.WebHost")));
            return services;
        }

        private static void TryLoadModuleAssembly(string moduleFolderPath, ModuleInfo module)
        {
            const string binariesFolderName = "bin";
            var binariesFolderPath = Path.Combine(moduleFolderPath, binariesFolderName);
            var binariesFolder = new DirectoryInfo(binariesFolderPath);

            if (Directory.Exists(binariesFolderPath))
            {
                foreach (var file in binariesFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
                {
                    Assembly assembly;
                    try
                    {
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file.FullName);
                    }
                    catch (FileLoadException)
                    {
                        // Get loaded assembly. This assembly might be loaded
                        assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));

                        if (assembly == null)
                        {
                            throw;
                        }

                        string loadedAssemblyVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                        string tryToLoadAssemblyVersion = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion;

                        // Or log the exception somewhere and don't add the module to list so that it will not be initialized
                        if (tryToLoadAssemblyVersion != loadedAssemblyVersion)
                        {
                            throw new Exception($"Cannot load {file.FullName} {tryToLoadAssemblyVersion} because {assembly.Location} {loadedAssemblyVersion} has been loaded");
                        }
                    }

                    if (Path.GetFileNameWithoutExtension(assembly.ManifestModule.Name) == module.Id)
                    {
                        module.Assembly = assembly;
                    }
                }
            }
        }

        private static Task HandleRemoteLoginFailure(RemoteFailureContext ctx)
        {
            ctx.Response.Redirect("/login");
            ctx.HandleResponse();
            return Task.CompletedTask;
        }
    }
}
