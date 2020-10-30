using System.Collections.Generic;
using Kooboos.API.Models;

namespace Kooboos.API.IngredientsLists
{
    public interface IIngredientsListRepository
    {
        IngredientsListDto GetByRecipeId(int recipeId);
        ICollection<IngredientsListItemDto> GetByIngredientsListId(int ingredientsListId);
    }
}