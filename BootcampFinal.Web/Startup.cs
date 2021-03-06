using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootcampFinal.Application.Interfaces;
using BootcampFinal.Application.Services;
using BootcampFinal.Data;
using BootcampFinal.Data.Repositories;
using BootcampFinal.Data.Repositories.Interfaces;
using BootcampFinal.Data.UnitOfWork;
using BootcampFinal.Data.UnitOfWork.Interfaces;
using BootcampFinal.Shared.SettingsModels;
using Microsoft.EntityFrameworkCore;

namespace BootcampFinal.Web
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
            services.AddDbContext<BootcampFinalDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<TourvisioApiSettings>(Configuration.GetSection("TourvisioApiSettings"));

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITourvisioApiService, TourvisioApiService>();


            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddTransient<IUserService,UserService>();
            services.AddMemoryCache();
            services.AddSession();
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

            app.UseSession();

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
