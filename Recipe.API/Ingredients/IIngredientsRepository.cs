using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public interface IIngredientsRepository
    {
        IList<IngredientDto> GetIngredients();

        IngredientDto GetIngredient(int id);

        int InsertIngredient(IngredientDto ingredientDto);

        void DeleteIngredient(IngredientDto ingredientDto);

        void UpdateIngredient(IngredientDto ingredientToUpdate, IngredientDto ingredientDtoWithNewValues);

        void Save();
    }
}