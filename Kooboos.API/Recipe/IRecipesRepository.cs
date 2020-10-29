using System.Collections.Generic;
using Kooboos.API.Models;

namespace Kooboos.API.Recipe
{
    public interface IRecipesRepository
    {
        IList<RecipeDto> GetRecipes();

        RecipeDto GetRecipe(int id);

        int InsertRecipe(RecipeDto recipeDto);

        void DeleteRecipe(RecipeDto recipeDto);

        void UpdateRecipe(RecipeDto recipeToUpdate, RecipeDto recipeDtoWithNewValues);
    }
}