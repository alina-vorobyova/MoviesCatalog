using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoviesCatalog.Data;

namespace MoviesCatalog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<MovieCatalogDbContext>();

                await dbContext.Database.MigrateAsync();

                var user = await userManager.FindByNameAsync("demo@movies.com");

                if (user is null)
                {
                    await userManager.CreateAsync(new IdentityUser
                    {
                        Email = "demo@movies.com",
                        UserName = "demo@movies.com",
                        EmailConfirmed = true
                    }, "Secret123$");
                }

                dbContext.SeedDatabase();
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
