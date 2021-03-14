using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

             services.AddControllers();
            //services.Add(new ServiceDescriptor(typeof(IMaths), new Maths()));
            services.AddSingleton<IMaths, Maths>();

            services.AddSingleton<IService, ServiceA>();
            services.AddSingleton<IService, ServiceB>();
            services.AddSingleton<IService, ServiceC>();

            services.AddTransient<Func<ServiceEnum, IService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case ServiceEnum.A:
                        return serviceProvider.GetService<ServiceA>();
                    case ServiceEnum.B:
                        return serviceProvider.GetService<ServiceB>();
                    case ServiceEnum.C:
                        return serviceProvider.GetService<ServiceC>();
                    default:
                        return null;
                }
            });


            services.AddMvc();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
                loggerFactory.AddFile("Logs/myapp-{Date}.txt");

             
            }
            else
            {
                app.UseExceptionHandler();
            }

           




            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
