using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Recipe.API.Base;
using Recipe.API.Contexts;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public class IngredientsRepository : BaseCrudRepository<Ingredient, IngredientDto>, IIngredientsRepository
    {
        public IngredientsRepository(RecipeContext recipeContext, IMapper mapper) : base(recipeContext, mapper)
        {

        }
    }
}