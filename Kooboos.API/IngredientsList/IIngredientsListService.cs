using Kooboos.API.Models;

namespace Kooboos.API.IngredientsLists
{
    public interface IIngredientsListService
    {
        IngredientsListDto GetByRecipeId(int recipeId);
        int InsertIngredientsListItem(int recipeId, IngredientsListItemDto ingredientListItemDto);
    }
}