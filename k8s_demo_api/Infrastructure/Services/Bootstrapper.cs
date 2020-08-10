using k8s_demo_api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace k8s_demo_api.Infrastructure.Services {
    public class Bootstrapper
    {
        public static void Bootstrap(IServiceCollection services)
        {


            services.AddHttpContextAccessor();


            // Swagger
            services.ConfigureSwagger();
            // MiniProfiler
            services.ConfigureMiniProfiler();

            // Make HTTP requests using IHttpClientFactory in ASP.NET Core
            services.AddHttpClient();
        }
    }
}
