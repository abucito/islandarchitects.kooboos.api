using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API
{
    public interface IRecipesRepository
    {
        IList<RecipeDto> GetRecipes();

        RecipeDto GetRecipe(int id);
    }
}