using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository recipesRepository;

        public RecipesService(IRecipesRepository recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }

        public IList<RecipeDTO> GetRecipes()
        {
            throw new System.NotImplementedException();
        }

        public RecipeDTO GetRecipe(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}