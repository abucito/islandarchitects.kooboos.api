using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public interface IIngredientsService
    {
        IList<IngredientDto> GetIngredients();

        IngredientDto GetIngredient(int validRecipeId);

        int InsertIngredient(IngredientDto ingredientDto);

        void DeleteIngredient(IngredientDto ingredientToDelete);

        void FullyUpdateIngredient(IngredientDto ingredientToUpdate, IngredientDto ingredientDtoWithNewValues);
    }
}