using System;
using AutoMapper;
using Kooboos.API.Contexts;

namespace Kooboos.API.IngredientsList
{
    public class IngredientsListRepository : IIngredientsListRepository
    {
        private readonly RecipeContext recipeContext;

        private readonly IMapper mapper;

        public IngredientsListRepository(RecipeContext recipeContext, IMapper mapper)
        {
            this.recipeContext = recipeContext ?? throw new ArgumentNullException();
            this.mapper = mapper ?? throw new ArgumentNullException();
        }
    }
}