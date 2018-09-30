using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;
using System;

namespace SimplCommerce.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("UPDATEDB", StringComparison.InvariantCultureIgnoreCase))
            {
                UpdateDb(args);
                return;
            }

            BuildWebHost2(args).Run();
        }

        // Changed to BuildWebHost2 to make EF don't pickup during design time
        private static IWebHost BuildWebHost2(string[] args) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureLogging(SetupLogging)
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder)
        {
            var env = hostingContext.HostingEnvironment;
            configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            configBuilder.AddEnvironmentVariables();

            var configuration = configBuilder.Build();
#if MSSQL
            configBuilder.AddEntityFrameworkConfig(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
#endif

#if NPGSQL
            configBuilder.AddEntityFrameworkConfig(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );
#endif
            Log.Logger = new LoggerConfiguration()
                       .ReadFrom.Configuration(configuration)
                       .CreateLogger();
        }

        private static void SetupLogging(WebHostBuilderContext hostingContext, ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddSerilog();
        }

        private static void UpdateDb(string[] args)
        {
            var factory = new MigrationSimplDbContextFactory();
            var context = factory.CreateDbContext(args);
            context.Database.Migrate();
            //using (var host = BuildWebHost2(args))
            //{
            //    var context = host.Services.GetRequiredService<SimplDbContext>();
            //    context.Database.Migrate();
            //}
        }
    }
}
