using System.Collections.Generic;
using Kooboos.API.Models;

namespace Kooboos.API.IngredientsLists
{
    public interface IIngredientsListRepository
    {
        IngredientsListDto GetByRecipeId(int recipeId);
        ICollection<IngredientsListItemDto> GetByIngredientsListId(int ingredientsListId);
        int InsertIngredientsListItem(int recipeId, IngredientsListItemDto ingredientListItemDto);
        bool RecipeExits(int recipeId);
        bool IngredientExists(int ingredientId);
        bool UnitExists(int unitId);
        bool IngredientsListItemExists(int itemId);
        void DeleteIngredientsListItem(int itemId);
    }
}