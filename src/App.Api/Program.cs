using Microsoft.AspNetCore;

namespace App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureLogging(logger =>
            {
                logger.ClearProviders();
                logger.AddConsole();
            })
            .UseStartup<Startup>()
            .UseUrls("http://localhost:7030/");
    }
}
