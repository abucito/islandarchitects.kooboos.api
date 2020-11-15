using AutoMapper;
using Kooboos.API.Base;
using Kooboos.API.Contexts;
using Kooboos.API.Ingredients.Entities;
using Kooboos.API.Ingredients.Models;

namespace Kooboos.API.Ingredients
{
    public class IngredientsRepository : BaseCrudRepository<Ingredient, IngredientDto>, IIngredientsRepository
    {
        public IngredientsRepository(RecipeContext recipeContext, IMapper mapper) : base(recipeContext, mapper)
        {

        }
    }
}