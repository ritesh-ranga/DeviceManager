using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeviceManager.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get the IWebHost which will host this application.
            var host = CreateHostBuilder(args).Build();

            // Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                // Get the instance of DeviceContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DeviceContext>();

                // Call the DataGenerator to create sample data
                DataSeeder.Initialize(services);
            }

            //Continue to run the application
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
