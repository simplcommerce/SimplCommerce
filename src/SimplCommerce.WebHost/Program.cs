using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.WebHost
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost2(args).Build().Run();
        }

        // Changed to BuildWebHost2 to make EF don't pickup during design time
        private static IHostBuilder BuildWebHost2(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(SetupConfiguration);
                    webBuilder.ConfigureLogging(SetupLogging);
                 });

        private static void SetupConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder)
        {
            var env = hostingContext.HostingEnvironment;
            var configuration = configBuilder.Build();
            configBuilder.AddEntityFrameworkConfig(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            Log.Logger = new LoggerConfiguration()
                       .ReadFrom.Configuration(configuration)
                       .CreateLogger();
        }
        private static void SetupLogging(WebHostBuilderContext hostingContext, ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddSerilog();
        }
    }
}
