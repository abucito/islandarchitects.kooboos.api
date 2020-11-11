using Kooboos.API.Base;
using Kooboos.API.Ingredients.Entities;
using Kooboos.API.Ingredients.Models;

namespace Kooboos.API.Ingredients
{
    public class IngredientsService : BaseCrudService<Ingredient, IngredientDto>, IIngredientsService
    {
        public IngredientsService(IIngredientsRepository ingredientsRepository) : base(ingredientsRepository)
        {

        }
    }
}