using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost2(args).Run();
        }

        // Changed to BuildWebHost2 to make EF don't pickup during design time
        private static IWebHost BuildWebHost2(string[] args) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(SetupConfiguration)
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder)
        {
            var env = hostingContext.HostingEnvironment;
            configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            configBuilder.AddEnvironmentVariables();

            var connectionStringConfig = configBuilder.Build();
            configBuilder.AddEntityFrameworkConfig(options =>
                    options.UseSqlServer(connectionStringConfig.GetConnectionString("DefaultConnection"))
            );
        }
    }
}
