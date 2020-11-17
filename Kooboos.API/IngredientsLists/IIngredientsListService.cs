using System.Collections.Generic;
using Kooboos.API.IngredientsLists.Models;

namespace Kooboos.API.IngredientsLists
{
    public interface IIngredientsListService
    {
        ICollection<IngredientsListDto> GetByRecipeId(int recipeId);
        int InsertIngredientsList(int recipeId, IngredientsListForCreationDto ingredientsListForCreationDto);
        int InsertIngredientsListItem(int recipeId, IngredientsListItemForCreationDto ingredientListItemForCreationDto);
        bool RecipeExists(int recipeId);
        bool IngredientExists(int ingredientId);
        bool UnitExists(int unitId);
        bool IngredientsListItemExists(int itemId);
        void DeleteIngredientsListItem(int itemId);
    }
}