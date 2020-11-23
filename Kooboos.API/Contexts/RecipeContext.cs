using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Kooboos.API.Recipes.Entities;
using Kooboos.API.Ingredients.Entities;
using Kooboos.API.Units.Entities;
using Kooboos.API.IngredientsLists.Entities;

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
            modelBuilder.Entity<Recipe>()
                .HasData(
                    new Recipe
                    {
                        Id = 1,
                        Title = "Cavatelli mit Caponata, Basilikum, Pinienkerne und Ricotta Salata",
                        Instruction = $"Für die Caponata die Auberginene in 2 cm grosse Würfel schneiden und in ein Sieb geben. Mit Salz bestreuen und 30 Minuten stehen lassen. "
                        + "Die Rosinen 15 Minuten in warmem Wasser einweichen. Die Ziwebel halbieren und in Streifen schneiden. "
                        + "Die Selleriestangen längs halbieren und schräg in 2 cm grosse Stücke schneiden. In einer Pfanneetwas Olivenöl erhitzen, die Ziebel und den Sellerie zugeben, "
                        + "den Knoblauch dazupressen und alles bei mittlerer Hitze zugedeckt 10 Minuten dünsten, ohne dass das Gemüse Farbe annimmt."
                        + "Die Oliven entsteinen und halbieren - dafür mit dem Boden eines Glases leicht auf jede Olive schlagen, den Stein aus dem aufgesprungenen Fleisch pulen und dieses halbieren. "
                        + "In einer grossen Bratpfanne grosszügig Olivenöl erhitzen, die Auberginenwürfel mit Küchenpapier trotcken tupfen und in zwei Durchgängen schön braun braten - "
                        + "sie sollen nicht zu weich werden. Den Zucker zum Sellerie geben, die Hitze aufdrehen, sodass der Zucker schmilzt, dann mit dem Rotweinessig ablöschen."
                        + "Die Pelati von Hand zerdrücken und mit den Kapern, den Rosinen, den Oliven und den Auberginenwürfeln zum Sellerie geben, alles einmal aufkochen und dann bei "
                        + "schwacher Hitze 5 Minuten köcheln. Mit Salz und Pfeffer abschmecken und etwas abkühlen lassen."
                    }
                );

            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient
                    {
                        Id = 1,
                        Name = "Auberginen"
                    },
                    new Ingredient
                    {
                        Id = 2,
                        Name = "Rosinen"
                    },
                    new Ingredient
                    {
                        Id = 3,
                        Name = "Zwiebel"
                    },
                    new Ingredient
                    {
                        Id = 4,
                        Name = "Selleriestangen"
                    },
                    new Ingredient
                    {
                        Id = 5,
                        Name = "Olivenöl"
                    },
                    new Ingredient
                    {
                        Id = 6,
                        Name = "Knoblauch"
                    },
                    new Ingredient
                    {
                        Id = 7,
                        Name = "Oliven mit Stein"
                    },
                    new Ingredient
                    {
                        Id = 8,
                        Name = "Zucker"
                    },
                    new Ingredient
                    {
                        Id = 9,
                        Name = "Rotweinessig"
                    },
                    new Ingredient
                    {
                        Id = 10,
                        Name = "ganze Pelati"
                    },
                    new Ingredient
                    {
                        Id = 11,
                        Name = "Kapern"
                    },
                    new Ingredient
                    {
                        Id = 12,
                        Name = "Salz"
                    },
                    new Ingredient
                    {
                        Id = 13,
                        Name = "schwarzer Pfeffer"
                    },
                    new Ingredient
                    {
                        Id = 14,
                        Name = "Pinienkerne"
                    },
                    new Ingredient
                    {
                        Id = 15,
                        Name = "Basilikum"
                    },
                    new Ingredient
                    {
                        Id = 16,
                        Name = "Ricotta salata"
                    }
                );

            modelBuilder.Entity<Unit>()
            .HasData(
                new Unit
                {
                    Id = 1,
                    Name = "g"
                },
                new Unit
                {
                    Id = 2,
                    Name = "Zehe"
                },
                new Unit
                {
                    Id = 3,
                    Name = "Stück"
                },
                new Unit
                {
                    Id = 4,
                    Name = "TL"
                },
                new Unit
                {
                    Id = 5,
                    Name = "dl"
                },
                new Unit
                {
                    Id = 6,
                    Name = "Zweig"
                },
                new Unit
                {
                    Id = 7,
                    Name = " "
                }
            );

            modelBuilder.Entity<IngredientsList>()
            .HasData(
                new IngredientsList
                {
                    Id = 1,
                    RecipeId = 1,
                    Title = "Caponata"
                },
                new IngredientsList
                {
                    Id = 2,
                    RecipeId = 1,
                    Title = "Zum Servieren"
                }
            );

            modelBuilder.Entity<IngredientsListItem>()
            .HasData(
                new IngredientsListItem
                {
                    Id = 1,
                    IngredientsListId = 1,
                    IngredientId = 1,
                    Quantity = 400,
                    UnitId = 1
                },
                new IngredientsListItem
                {
                    Id = 2,
                    IngredientsListId = 1,
                    IngredientId = 2,
                    Quantity = 35,
                    UnitId = 1,
                },
                new IngredientsListItem
                {
                    Id = 3,
                    IngredientsListId = 1,
                    IngredientId = 3,
                    Quantity = 1,
                    UnitId = 2
                },
                new IngredientsListItem
                {
                    Id = 4,
                    IngredientsListId = 1,
                    IngredientId = 4,
                    Quantity = 3,
                    UnitId = 2
                },
                new IngredientsListItem
                {
                    Id = 5,
                    IngredientsListId = 1,
                    IngredientId = 5,
                    Quantity = 1,
                    UnitId = 2
                },
                new IngredientsListItem
                {
                    Id = 6,
                    IngredientsListId = 1,
                    IngredientId = 6,
                    Quantity = 1,
                    UnitId = 3
                },
                new IngredientsListItem
                {
                    Id = 7,
                    IngredientsListId = 1,
                    IngredientId = 7,
                    Quantity = 35,
                    UnitId = 1
                },
                new IngredientsListItem
                {
                    Id = 8,
                    IngredientsListId = 1,
                    IngredientId = 8,
                    Quantity = 1,
                    UnitId = 4
                },
                new IngredientsListItem
                {
                    Id = 9,
                    IngredientsListId = 1,
                    IngredientId = 9,
                    Quantity = 0.3f,
                    UnitId = 5
                },
                new IngredientsListItem
                {
                    Id = 10,
                    IngredientsListId = 1,
                    IngredientId = 10,
                    Quantity = 150,
                    UnitId = 1
                },
                new IngredientsListItem
                {
                    Id = 11,
                    IngredientsListId = 1,
                    IngredientId = 11,
                    Quantity = 20,
                    UnitId = 1
                },
                new IngredientsListItem
                {
                    Id = 12,
                    IngredientsListId = 1,
                    IngredientId = 12,
                    Quantity = 0,
                    UnitId = 7
                },
                new IngredientsListItem
                {
                    Id = 13,
                    IngredientsListId = 1,
                    IngredientId = 13,
                    Quantity = 0,
                    UnitId = 7
                },
                new IngredientsListItem
                {
                    Id = 14,
                    IngredientsListId = 2,
                    IngredientId = 14,
                    Quantity = 60,
                    UnitId = 1
                },
                new IngredientsListItem
                {
                    Id = 15,
                    IngredientsListId = 2,
                    IngredientId = 5,
                    Quantity = 0,
                    UnitId = 7
                },
                new IngredientsListItem
                {
                    Id = 16,
                    IngredientsListId = 2,
                    IngredientId = 15,
                    Quantity = 4,
                    UnitId = 6
                },
                new IngredientsListItem
                {
                    Id = 17,
                    IngredientsListId = 2,
                    IngredientId = 16,
                    Quantity = 0,
                    UnitId = 7
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<IngredientsList> IngredientsLists { get; set; }

        public DbSet<IngredientsListItem> IngredientsListItems { get; set; }
    }
}