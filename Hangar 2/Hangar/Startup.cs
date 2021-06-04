using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Hangar.Dao;
using Hangar.Dao.AirCraft;
using Hangar.Dao.Hangar;
using Hangar.HangarContracts;
using Hangar.Models.Hangar;
using Hangar.Models.Plane;
using Hangar.Orchestrators.Hangar;
using Hangar.Orchestrators.Plane;
using Hangar.PlaneContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hangar
{
    public class Startup
    
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connString = Configuration.GetConnectionString("HangarDB");
            services.AddDbContext<HangarContext>(options => options.UseSqlServer(connString));
            services.AddAutoMapper(typeof(HangarProfile), typeof(AirCraftProfile));
            services.AddScoped<IHangarRepository, HangarRepository>();
            services.AddScoped<IHangarService, HangarService>();
            services.AddScoped<IPlaneRepository, AirCraftRepository>();
            services.AddScoped<IPlaneService, AirCraftService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}