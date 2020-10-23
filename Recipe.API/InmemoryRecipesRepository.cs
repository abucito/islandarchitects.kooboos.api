using System.Collections.Generic;
using Recipe.API.Models;
using System.Linq;

namespace Recipe.API
{
    public class InmemoryRecipeRepository : IRecipesRepository
    {
        private readonly IList<RecipeDto> recipes;

        public InmemoryRecipeRepository()
        {
            recipes = new List<RecipeDto> {
                new RecipeDto
                {
                    Id = 1,
                    Title = "My first Recipe",
                    Instruction = "You should cook it!"
                },

                new RecipeDto
                {
                    Id = 2,
                    Title = "My second Recipe",
                    Instruction = "You should bake it!"
                }
            };
        }

        public IList<RecipeDto> GetRecipes()
        {
            return recipes;
        }

        public RecipeDto GetRecipe(int id)
        {
            return recipes.FirstOrDefault(r => r.Id == id);
        }

        public int InsertRecipe(RecipeDto recipeDto)
        {
            var idForNewRecipe = recipes.Max(r => r.Id) + 1;
            recipeDto.Id = idForNewRecipe;
            recipes.Add(recipeDto);
            return idForNewRecipe;
        }

        public void DeleteRecipe(RecipeDto recipeDto)
        {
            var recipeToDelete = recipes.FirstOrDefault(r => r.Id == recipeDto.Id);
            if (recipeToDelete != null)
            {
                recipes.Remove(recipeToDelete);
            }
        }

        public void UpdateRecipe(RecipeDto recipeToUpdate, RecipeDto recipeDtoWithNewValues)
        {
            recipeToUpdate.Title = recipeDtoWithNewValues.Title;
            recipeToUpdate.Instruction = recipeDtoWithNewValues.Instruction;
        }

        public void Save()
        {
            // we do not need to do anything here
        }
    }
}