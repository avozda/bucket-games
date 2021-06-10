using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using bucket_soldier_games.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using bucket_soldier_games.Interfaces;
using bucket_soldier_games.Repositories;
using System;
using Microsoft.AspNetCore.Http;
using bucket_soldier_games.Models;
using Microsoft.AspNetCore.Mvc;

namespace bucket_soldier_games
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
       

        public Startup(IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IGameRepository, GameRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();




            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "drinkdetails",
                   template: "Drink/Details/{drinkId?}",
                   defaults: new { Controller = "Drink", action = "Details" });

                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Game/{action}/{category?}",
                    defaults: new { Controller = "Game", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{Id?}");
            });


            DbInitializer.Seed(serviceProvider);
        }
    }
}
