using Kooboos.API.Models;

namespace Kooboos.API.IngredientsLists
{
    public interface IIngredientsListService
    {
        IngredientsListDto GetByRecipeId(int recipeId);
    }
}