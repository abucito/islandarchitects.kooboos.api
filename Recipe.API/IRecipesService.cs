using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API
{
    public interface IRecipesService
    {
        IList<RecipeDTO> GetRecipes();

        RecipeDTO GetRecipe(int id);
    }
}