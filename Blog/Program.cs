using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using ILogger = NLog.ILogger;

namespace Blog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("Start App");
                var host = CreateHostBuilder(args).Build();
                //Initialize DB start data : role and admin, user
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var userManager = services.GetRequiredService<UserManager<User>>();
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                        await RoleInitializer.InitializeAsync(userManager, roleManager);
                    }
                    catch (Exception ex)
                    {
                        var log = services.GetRequiredService<ILogger<Program>>();
                        log.LogError(ex, "An error occurred while seeding the database.");
                    }
                }


                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "App run was unsuccessful");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseNLog();
    }
}
