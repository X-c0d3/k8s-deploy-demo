using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace k8s_demo_api {
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, config) => config.ClearProviders())
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
            //.UseServiceProviderFactory(new DryIocServiceProviderFactory())
            //.ConfigureContainer<Container>((hostContext, container) => new DryIocCompositionRoot(container));
    }
}
