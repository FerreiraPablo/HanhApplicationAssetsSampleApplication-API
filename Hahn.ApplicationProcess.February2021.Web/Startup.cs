using System;
using System.IO;
using System.Reflection;
using FluentValidation;
using Hahn.ApplicationProcess.February2021.Data.Contexts;
using Hahn.ApplicationProcess.February2021.Data.Repositories.Assets;
using Hahn.ApplicationProcess.February2021.Data.Repositories.Countries;
using Hahn.ApplicationProcess.February2021.Domain.BusinessLogic;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using Hahn.ApplicationProcess.February2021.Domain.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Hahn.ApplicationProcess.February2021.Web
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
            services.AddDbContext<AssetsDatabaseContext>(x => x.UseInMemoryDatabase("Assets"));
            services.AddTransient<ICountryRepository, RestCountryRepository>();
            services.AddTransient<AbstractValidator<Asset>, AssetValidator>();
            services.AddScoped<IAssetRepository, DatabaseAssetRepository>();
            services.AddScoped<IAssetsLogic, AssetsLogic>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {

                    Version = "v1",
                    Title = "Hahn Sample Asset API",
                    Description = "REST API for Asset Control",
                    Contact = new OpenApiContact
                    {
                        Name = "Pablo Ferreira",
                        Email = "pferreira@universal.com.do",
                        Url = new Uri("https://ferreirapablo.com"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile.Replace("Web", "Domain")));
            });


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn Sample Asset API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
