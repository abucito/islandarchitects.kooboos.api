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

        public RecipeContext(
            IConfiguration configuration,
            DbContextOptions options) : base(options)
        {
            this.configuration = configuration ?? throw new ArgumentNullException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Test_RecipeDb"));

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

            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient
                    {
                        Id = 1,
                        Name = "Black Pepper",
                        Description = "Spice up your life!"
                    }
                );

            modelBuilder.Entity<Unit>()
            .HasData(
                new Unit
                {
                    Id = 1,
                    Name = "Spoon"
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}