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
using EssenceRealty.Data.Identity;
using System.Collections.Generic;
using EssenceRealty.Web.Api.Utility;
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
            AddSwagger(services);
            services.Configure<EssenceApiConfig>(Configuration.GetSection("ERConfiguration"));

            services.AddControllers();
       

            services.AddPersistenceServices(Configuration);
            services.AddHttpClient("vault", options =>
            {
                options.BaseAddress = new Uri(Configuration.GetSection("ERConfiguration:vaultUrl").Value);
                options.DefaultRequestHeaders.Add("accept", "application/json");
                options.DefaultRequestHeaders.Add("X-Api-Key", Environment.GetEnvironmentVariable("VAULT_API_KEY"));
                options.DefaultRequestHeaders.Add("Authorization", "Bearer " + Environment.GetEnvironmentVariable("VAULT_BEARER_TOKEN"));

            });

            services.AddIdentityServices(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Essence Realty Management API",

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

          
            //   app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

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
