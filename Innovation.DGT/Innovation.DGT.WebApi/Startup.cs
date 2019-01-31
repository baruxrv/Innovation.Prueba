using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Innovation.DGT.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Innovation.DGT.Domain;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.DBContext.Entities;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;

namespace Innovation.DGT.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).Services
            .AddDbContext<DgtDbContext>(options => options.UseSqlite("Filename=./Dgt.db", b => b.MigrationsAssembly("Innovation.DGT.WebApi")))
            .AddTransient<IDriver, DriverLogic>()
            .AddTransient<IGet<Driver>, DriverLogic>()
            .AddTransient<IModifications<Driver>, DriverLogic>()
            .AddTransient<IModifications<Vehicle>, VehicleLogic>()
            .AddTransient<IGet<Vehicle>, VehicleLogic>()
            .AddTransient<IModifications<Infringement>, InfringementLogic>()
            .AddTransient<IGet<Infringement>, InfringementLogic>()
            .AddTransient<IInfringement, InfringementLogic>();

            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new Info { Title = "Innovation Prueba - Api DGT", Version = "v1" });
              });

            services.AddAutoMapper();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Innovation DGT");
                });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
