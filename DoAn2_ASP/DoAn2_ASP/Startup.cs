using AspNetCoreHero.ToastNotification;
<<<<<<< HEAD
<<<<<<< HEAD
using DoAn2_ASP.Data;
using DoAn2_ASP.Models;
=======
using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
>>>>>>> 8ceeb82 (giang)
=======
using DoAn2_ASP.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
>>>>>>> main
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace DoAn2_ASP
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
<<<<<<< HEAD
<<<<<<< HEAD
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
=======
=======
>>>>>>> main
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(p =>
             {
                // p.Cookie.Name = "UserLoginCookie";
                 //p.ExpireTimeSpan = TimeSpan.FromDays(1);
                    p.LoginPath = "/Accounts/login";
                    //p.LogoutPath = "/dang-xuat/html";
                   p.AccessDeniedPath = "/";
             });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSession();
<<<<<<< HEAD
>>>>>>> 8ceeb82 (giang)
=======
>>>>>>> main
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
            services.AddDbContext<DoAn2_ASP.Models.QL_ThuVienContext>();
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
<<<<<<< HEAD
<<<<<<< HEAD

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
=======
            app.UseSession();
            app.UseRouting(); 
            app.UseAuthentication();
            app.UseAuthorization();
            
            
>>>>>>> 8ceeb82 (giang)
=======
            app.UseSession();
            app.UseRouting(); 
            app.UseAuthentication();
            app.UseAuthorization();
            
            
>>>>>>> main

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
