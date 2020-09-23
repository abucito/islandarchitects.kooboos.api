using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API
{
    public interface IRecipesService
    {
        IList<RecipeDTO> GetRecipies();
    }
}