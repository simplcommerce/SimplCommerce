using System;
using Autofac;

namespace ResourceBuilder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var container = ContainerConfig.Configure();

                using (var scope = container.BeginLifetimeScope())
                {
                    var app = scope.Resolve<IApplication>();

                    app.Run();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}