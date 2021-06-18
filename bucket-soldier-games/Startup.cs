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
using Microsoft.AspNetCore.Authentication.Cookies;

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
            services.AddCoreAdmin();

           
            services.AddAuthentication()
        .AddGoogle(options =>
        {
            IConfigurationSection googleAuthNSection =
                Configuration.GetSection("Authentication:Google");

            options.ClientId = "161507113259-ehmk9i8var51p9ne6gmr62jpfh34lam5.apps.googleusercontent.com";
            options.ClientSecret = "W7y1PNtWCR0afBZJaxU3tddZ";
        }).AddFacebook(facebookOptions =>
        {
            facebookOptions.AppId = "313798386871522";
            facebookOptions.AppSecret = "68b2486361428468c1b39cf166e4fa52";
        }).AddTwitter(twitterOptions =>
        {
            twitterOptions.ConsumerKey = "MAiFL4afrNW7Tm2D9YkomnMCv";
            twitterOptions.ConsumerSecret = "HRW0asXuoCjaAXgfiqUDg89KjRWUrHbJUIECvmN2hBo7EO28g8";
            twitterOptions.RetrieveUserDetails = true;
        }).AddMicrosoftAccount(microsoftOptions =>
        {
            microsoftOptions.ClientId = "2e88813a-6a96-4f3d-8b63-115a938acb80";
            microsoftOptions.ClientSecret = "_nG1Q6h_CO8oqoIrEKvy5RJaZ-7S2F7_47";
        });
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
