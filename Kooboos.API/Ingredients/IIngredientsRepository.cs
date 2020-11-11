using Kooboos.API.Base;
using Kooboos.API.Ingredients.Entities;
using Kooboos.API.Ingredients.Models;

namespace Kooboos.API.Ingredients
{
    public interface IIngredientsRepository : IBaseCrudRepository<Ingredient, IngredientDto>
    {

    }
}