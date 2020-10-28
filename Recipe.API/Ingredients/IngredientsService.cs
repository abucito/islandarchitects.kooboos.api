using System;
using System.Collections.Generic;
using Recipe.API.Base;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public class IngredientsService : BaseCrudService<Ingredient, IngredientDto>, IIngredientsService
    {
        public IngredientsService(IIngredientsRepository ingredientsRepository) : base(ingredientsRepository)
        {

        }
    }
}