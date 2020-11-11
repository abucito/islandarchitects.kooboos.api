using System.Collections.Generic;
using Kooboos.API.Recipes.Models;

namespace Kooboos.API.Recipes
{
    // Kooboos is great
    public interface IRecipesService
    {
        IList<RecipeDto> GetRecipes();

        RecipeDto GetRecipe(int id);

        int InsertRecipe(RecipeDto recipeDto);

        void DeleteRecipe(RecipeDto recipeToDelete);

        void FullyUpdateRecipe(RecipeDto recipeToUpdate, RecipeDto recipeDtoWithNewValues);
    }
}