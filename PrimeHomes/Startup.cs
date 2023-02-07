using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrimeHomes.Areas.Identity.Data;
using PrimeHomes.Data;
using PrimeHomes.Data.Service;
using PrimeHomes.Data.Services;
using PrimeHomes.Models;
using SmartBreadcrumbs.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PrimeHomes
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddDefaultUI(); ; 
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IBathroomService, BathroomsService>();
            services.AddScoped<IBedroomService, BedroomService>();
            services.AddScoped<IFeaturesService, FeaturesService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITeamMembersService, TeamMembersService>();
            services.AddMemoryCache();
            services.AddSession();
            
            services.AddRazorPages();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Identity/Account/Login");
                options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
                
            });
          
           
            services.AddTransient<IEmailSender, SendGridEmailSender>();
            services.Configure<SendGridEmailSenderOptions>(options =>
            {
                options.ApiKey = "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";
                options.SenderEmail = "PrimeHomes633@gmail.com";
                options.SenderName = "PrimeHomes";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
            AppDbInitializer.Seed(app);
        }
    }
}
