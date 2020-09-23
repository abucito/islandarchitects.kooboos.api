using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API
{
    public interface IRecipesService
    {
        IList<RecipeDto> GetRecipes();

        RecipeDto GetRecipe(int id);
    }
}