using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API
{
    public class InmemoryRecipeRepository : IRecipesRepository
    {
        private readonly IList<RecipeDTO> recipes;

        public InmemoryRecipeRepository()
        {
            recipes = new List<RecipeDTO> {
                new RecipeDTO
                {
                    Title = "My first Recipe",
                    Instruction = "You should cook it!"
                },

                new RecipeDTO
                {
                    Title = "My second Recipe",
                    Instruction = "You should bake it!"
                }
            };
        }
    }
}