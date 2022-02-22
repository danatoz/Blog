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
using Blog.Common.Config;
using Blog.DAL.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<ApplicationContext>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            SharedConfiguration.UpdateSharedConfiguration(Configuration.GetConnectionString("DefaultConnectionString"), loggerFactory);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Append(HeaderNames.CacheControl, "public,max-age=31622400");
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PublicDefaultRoute",
                    pattern: "{controller=Home}/{action=Index}/{id?}", 
                    new { area = "Public" });

                endpoints.MapControllerRoute(
                    name: "PublicErrorRoute",
                    pattern: "{controller=Error}/{code:int}",
                    new { area = "Public", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "AdminDefaultRoute",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
                    new { area = "Admin" });

                endpoints.MapControllerRoute(
                    name: "AdminErrorRoute",
                    pattern: "Admin/{controller=Error}/{code:int}",
                    defaults: new { area = "Admin", action = "Index" });

            });
        }
    }
}
