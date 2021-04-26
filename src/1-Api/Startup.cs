using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Efactura.Application;
using Efactura.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Efactura.WebApi.Extensions;
using FluentValidation.AspNetCore;
using Efactura.Application.Features.Commands.CreateUser;

namespace Efactura.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Efactura Users API",
                        Description = "Efactura API for showing Task Profile",
                        Version = "v1"
                    });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });

            services.AddApplicationRegistration();
           
            services.AddPersistenceRegistration();

            services.AddControllers();

            services.AddMvc()
             .AddFluentValidation(fv =>
             {
                 fv.ImplicitlyValidateChildProperties = true;
                 fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommand>();
             });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(builder => builder
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod());
            }

            app.UseExceptionHandler(
               builder =>
               {
                   builder.Run(
                       async context =>
                       {
                           context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                           context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                           var error = context.Features.Get<IExceptionHandlerFeature>();
                           if (error != null)
                           {
                               context.Response.AddApplicationError(error.Error.Message);
                               await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                           }
                       });
               });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Efactura Users API");
                options.RoutePrefix = "";
            });
        }
    }
}
