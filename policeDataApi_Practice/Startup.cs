using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using policeDataApi_Practice.Data;

namespace policeDataApi_Practice
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
            services.AddControllersWithViews();
            services.AddHttpClient();

            services.AddHttpClient("street-level-all-crimes", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("StreetLevelAllCrimesAPI"));
            });

            services.AddHttpClient("street-level-crimes", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("StreetLevelCrimesByCategoryAPI"));
            });

            services.AddHttpClient("street-level-outcomes", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("StreetLevelOutcomesAPI"));
            });

            services.AddHttpClient("lookup-postcode", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("LookUpPostcodeAPI"));
            });


            services.AddScoped<IStreetLevelCrimesRepo, CallStreetLevelCrimesApiRepo>();
            services.AddScoped<IStreetLevelOutcomesRepo, CallStreetLevelOutcomesApiRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
