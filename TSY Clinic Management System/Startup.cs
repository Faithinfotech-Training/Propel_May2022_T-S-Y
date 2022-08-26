using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.Repository;

namespace TSY_Clinic_Management_System
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
            //Add Dependency injection for CLINIC_DBContext
            services.AddDbContext<CLINIC_DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevelopConnection")));
            
            //Add services for Login Repository
            services.AddScoped<ILoginRep, LoginRep>();
            services.AddScoped<IMedicineRepo, MedicineRepo>();
            services.AddScoped<IMedicinePrescriptionRepo, MedicinePrescriptionRepo>();
            services.AddScoped<IMedViewRepo, MedicineViewRepo>();
            services.AddScoped<IBillGeneration, BillRepository>();

            //Adding services
            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    //Enables text json - display exact match
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //Enables to avoid Infinite looping.It is also known as Recursive
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            //Enable Cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Visual studio code
            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            //.AllowCredentials()
            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //use cors
            app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowCredentials());

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
