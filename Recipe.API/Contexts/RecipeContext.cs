using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Recipe.API.Entities;

namespace Recipe.API.Contexts
{
    public class RecipeContext : DbContext
    {
        private readonly IConfiguration configuration;

        private readonly IWebHostEnvironment environment;

        public RecipeContext(
            IConfiguration configuration,
            IWebHostEnvironment environment,
            DbContextOptions options) : base(options)
        {
            this.configuration = configuration ?? throw new ArgumentNullException();
            this.environment = environment ?? throw new ArgumentNullException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (environment.IsDevelopment())
            {
                optionsBuilder.UseSqlite(configuration.GetConnectionString("Test_RecipeDb"));
            }
            else
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Test_RecipeDb"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Recipe>()
                .HasData(
                    new Entities.Recipe
                    {
                        Id = 1,
                        Title = "WTF Recipe",
                        Instruction = "Just some Instructions"
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Recipe> Recipes { get; set; }
    }
}