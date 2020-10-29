using System.Collections.Generic;
using Kooboos.API.Models;

namespace Kooboos.API.Recipe
{
    public interface IRecipesService
    {
        IList<RecipeDto> GetRecipes();

        RecipeDto GetRecipe(int id);

        int InsertRecipe(RecipeDto recipeDto);

        void DeleteRecipe(RecipeDto recipeToDelete);

        void FullyUpdateRecipe(RecipeDto recipeToUpdate, RecipeDto recipeDtoWithNewValues);
    }
}