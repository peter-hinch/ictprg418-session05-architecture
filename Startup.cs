using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05Architecture
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The function acts as middleware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
            // Search for an endpoint using routing methods
            app.UseRouting(); 

            app.UseEndpoints(endpoints =>
            {
                // Map an endpoint to a URL
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            */

            // Without endpoints, a similar result can be achieved by the following:
            // When multiple middleware are required, use app.Use() and await.Next()
            // to execute all items.
            // Reference: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-5.0
            
            // This is the first middleware in the pipeline.
            app.Use(async (context, next) => 
            {
                await context.Response.WriteAsync("Hello Planet #1!");
                    
                // Move to the next item.
                await next();
            });

            // This is the second middleware in the pipeline.
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\nHello Planet #2!");
            });
        }
    }
}
