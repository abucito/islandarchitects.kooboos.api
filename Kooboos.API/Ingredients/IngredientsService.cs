using System;
using System.Collections.Generic;
using Kooboos.API.Base;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.Ingredients
{
    public class IngredientsService : BaseCrudService<Ingredient, IngredientDto>, IIngredientsService
    {
        public IngredientsService(IIngredientsRepository ingredientsRepository) : base(ingredientsRepository)
        {

        }
    }
}