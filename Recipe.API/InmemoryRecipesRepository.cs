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
                    Title = "My first Recipe",
                    Instruction = "You should cook it!"
                },

                new RecipeDto
                {
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
    }
}