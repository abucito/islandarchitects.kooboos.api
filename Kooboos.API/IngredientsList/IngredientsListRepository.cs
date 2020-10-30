using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Kooboos.API.Contexts;
using Kooboos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kooboos.API.IngredientsLists
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

        public IngredientsListDto GetByRecipeId(int recipeId)
        {
            var ingredientsList = recipeContext.IngredientsLists.Find(recipeId);
            return mapper.Map<IngredientsListDto>(ingredientsList);
        }

        public ICollection<IngredientsListItemDto> GetByIngredientsListId(int ingredientsListId)
        {
            var ingredientsListItems = recipeContext.IngredientsListItems
                .Include(i => i.Ingredient)
                .Include(i => i.Unit)
                .Where(i => i.IngredientsListId == ingredientsListId)
                .ToList();

            return ingredientsListItems.Select(i => mapper.Map<IngredientsListItemDto>(i)).ToList();
        }
    }
}