using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kooboos.API.Base;
using Kooboos.API.Contexts;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.Ingredients
{
    public class IngredientsRepository : BaseCrudRepository<Ingredient, IngredientDto>, IIngredientsRepository
    {
        public IngredientsRepository(RecipeContext recipeContext, IMapper mapper) : base(recipeContext, mapper)
        {

        }
    }
}