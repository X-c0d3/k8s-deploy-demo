using k8s_demo_api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace k8s_demo_api.Infrastructure.Services
{
    public class Bootstrapper
    {
        public static void Bootstrap(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(opt =>
                {
                    opt.AllowCombiningAuthorizeFilters = false;
                    //opt.Filters.Add(typeof(ResourceFilter));
                }) // Important note: set this value to "false" to prevent call to other filter when one filer has failed.
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

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
