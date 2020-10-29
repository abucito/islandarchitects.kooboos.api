using System.Collections.Generic;
using Kooboos.API.Base;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.Ingredients
{
    public interface IIngredientsRepository : IBaseCrudRepository<Ingredient, IngredientDto>
    {

    }
}