using AdoptiverseAPI.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdoptiverseAPI.Controllers;

namespace AdoptiverseEndpointTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                        Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        //THIS IS THE CODE TO ADD:
                        services.AddDbContext<AdoptiverseApiContext>(options =>
                            options.UseInMemoryDatabase("TestDatabase"));

                        services.AddControllers().AddApplicationPart(typeof(SheltersController).Assembly);
                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}