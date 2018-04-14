
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace EventManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) => {
                    config.Sources.Clear();
                    config.AddJsonFile("appsettings.json", optional: true);
                })
                .Build();
    }
}
