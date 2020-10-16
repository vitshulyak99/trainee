using System;
using System.Globalization;
using LuckyDucky.Lottery.Interfaces;
using LuckyDucky.MailService.Interfaces;
using LuckyDucky.MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LuckyDucky.MVC {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = ".AlwaysTakePartFrom";
            //    options.ExpireTimeSpan = TimeSpan.FromDays(30);
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.SlidingExpiration = true;
            //    //options.Cookie.SecurePolicy
            //});

            

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".LuckyDucky.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(15);

            });
            
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

            services.AddTransient<IMailService, MailService.MailService>();
            services.AddControllersWithViews()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opt => opt.ResourcesPath = "Resources")
                    .AddDataAnnotationsLocalization(options => {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                            factory.Create(typeof(TakePartModel));
                    });
          
            //services.AddMvc()
            //    .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddTransient<ILotteryService, Lottery.LotteryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            var supportedCultures = new[]
            {
//                new CultureInfo("en-US"),
                new CultureInfo("en"),
//                new CultureInfo("ru-RU"),
                new CultureInfo("ru")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints => {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

               
            });

        }
    }
}
