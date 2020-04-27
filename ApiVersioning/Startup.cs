using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVersioning.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiVersioning
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

            services.AddApiVersioning(options => {
                options.DefaultApiVersion = new ApiVersion(1, 1);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                                new QueryStringApiVersionReader("v"),
                                new HeaderApiVersionReader("v"));
                
                options.Conventions.Controller<WeatherForecastController>()
                   .HasDeprecatedApiVersion(1, 0)
                   .HasApiVersion(1, 1)
                   .HasApiVersion(2, 0)
                   .Action(c => c.Get1_0()).MapToApiVersion(1, 0)
                   .Action(c => c.Get1_1()).MapToApiVersion(1, 1)
                   .Action(c => c.Get2_0()).MapToApiVersion(2, 0);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
