using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Kooboos.API.Entities;

namespace Kooboos.API.Contexts
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

            modelBuilder.Entity<IngredientsList>()
            .HasData(
                new IngredientsList
                {
                    Id = 1,
                    RecipeId = 1
                }
            );

            modelBuilder.Entity<IngredientsListItem>()
            .HasData(
                new IngredientsListItem
                {
                    Id = 1,
                    IngredientId = 1,
                    Quantity = 1,
                    UnitId = 1,
                    IngredientsListId = 1
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientsList> IngredientsLists { get; set; }

        public DbSet<IngredientsListItem> IngredientsListItems { get; set; }
    }
}