using Kooboos.API.IngredientsLists.Models;

namespace Kooboos.API.IngredientsLists
{
    public interface IIngredientsListService
    {
        IngredientsListDto GetByRecipeId(int recipeId);
        int InsertIngredientsListItem(int recipeId, IngredientsListItemForCreationDto ingredientListItemForCreationDto);
        bool RecipeExists(int recipeId);
        bool IngredientExists(int ingredientId);
        bool UnitExists(int unitId);
        bool IngredientsListItemExists(int itemId);
        void DeleteIngredientsListItem(int itemId);
    }
}