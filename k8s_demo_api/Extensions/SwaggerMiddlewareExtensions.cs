using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace k8s_demo_api.Extensions
{
    public static class SwaggerMiddlewareExtensions
    {
        public static void ConfigureSwaggerMiddleware(this IApplicationBuilder app, bool IsRedirectToDefaultPage)
        {
            app.UseSwagger();
            //https://github.com/aspnet/AspNetCore/issues/2302
            // for support reverse proxy with prefix path  Ex.  domain.com/v3/prefix/api
            string basePath = Environment.GetEnvironmentVariable("ASPNETCORE_BASEPATH");
            if (!string.IsNullOrEmpty(basePath))
            {
                app.UsePathBase(basePath);
                app.Use(async (context, next) =>
                {
                    context.Request.PathBase = basePath;
                    await next.Invoke();
                });

                app.UseSwagger(c =>
                {
                   // c.PreSerializeFilters.Add((swaggerDoc, httpRequest) => { swaggerDoc.BasePath = basePath; });
                });
            }

            app.UseSwaggerUI(c =>
            {
                c.IndexStream = () => Assembly.GetExecutingAssembly().GetManifestResourceStream("k8s_demo_api.Swagger.index.html");
                c.SwaggerEndpoint(basePath + "/swagger/v1/swagger.json", "API V1");
            });

            if (IsRedirectToDefaultPage)
            {
                //Redirect default start page to Swagger
                app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
            }
        }
    }
}
