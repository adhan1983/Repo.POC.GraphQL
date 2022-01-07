using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using POC.GraphQL.Api.Extensions;

namespace POC.GraphQL.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).
                Build().
                MigrateDatabase().
                Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
