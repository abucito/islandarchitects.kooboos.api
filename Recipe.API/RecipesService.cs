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

        public IList<RecipeDTO> GetRecipies()
        {
            throw new System.NotImplementedException();
        }
    }
}