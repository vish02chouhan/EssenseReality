using EssenceRealty.Repository;
using EssenceRealty.Data;
using EssenceRealty.Web.API.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EssenceRealty.Web.API.Model;
using System;

namespace EssenceRealty.Web.API
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

            services.Configure<EssenceApiConfig>(Configuration.GetSection("ERConfiguration"));

            services.AddControllers();

            services.AddPersistenceServices(Configuration);
            services.AddHttpClient("vault", options =>
            {
                options.BaseAddress = new Uri(Configuration.GetSection("ERConfiguration:vaultUrl").Value);
                options.DefaultRequestHeaders.Add("ApiKey", "2YlnaCvpeL63JTNtjOyG55GYcKNwfpbZ1qwYIWSa");//Environment.GetEnvironmentVariable("VAULT_API_KEY");
                options.DefaultRequestHeaders.Add("BearerToken", "fkyqnqciqnpxkdaxvyddwojnnvxnepqaspcxmooh");//Environment.GetEnvironmentVariable("VAULT_BEARER_TOKEN")

            });

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EssenceRealty.Web.API", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EssenceRealty.Web.API v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/essencerealty/swagger/v1/swagger.json", "EssenceRealty.Web.API v1"));
            }
          

            //   app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();
            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
