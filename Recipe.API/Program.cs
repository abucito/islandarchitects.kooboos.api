using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recipe.API.Contexts;

namespace Recipe.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // using (var scope = host.Services.CreateScope())
            // {
            //     try
            //     {
            //         var context = scope.ServiceProvider.GetService<RecipeContext>();

            //         // for demo purposes, delete the database & migrate on startup so 
            //         // we can start with a clean slate
            //         context.Database.EnsureDeleted();
            //         context.Database.EnsureCreated();
            //         context.Database.Migrate();
            //     }
            //     catch (Exception exception)
            //     {
            //     }
            // }

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
