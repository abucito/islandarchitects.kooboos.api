using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Kooboos.API.Contexts;
using Kooboos.API.Models;
using Microsoft.EntityFrameworkCore;
using Kooboos.API.Entities;

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
            var ingredientsList = recipeContext.IngredientsLists.SingleOrDefault(il => il.RecipeId == recipeId);
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

        public int InsertIngredientsListItem(int recipeId, IngredientsListItemForCreationDto ingredientListItemForCreationDto)
        {
            var ingredientsList = recipeContext.IngredientsLists.SingleOrDefault(il => il.RecipeId == recipeId);
            if (ingredientsList == null)
            {
                ingredientsList = new IngredientsList
                {
                    RecipeId = recipeId
                };
                recipeContext.Add(ingredientsList);
            }

            var ingredientsListItem = mapper.Map<IngredientsListItem>(ingredientListItemForCreationDto);
            ingredientsListItem.IngredientsList = ingredientsList;
            recipeContext.Add(ingredientsListItem);
            recipeContext.SaveChanges();
            return ingredientsListItem.Id;
        }

        public bool RecipeExits(int recipeId)
        {
            return recipeContext.Recipes.Find(recipeId) != null;
        }

        public bool IngredientExists(int ingredientId)
        {
            return recipeContext.Ingredients.Find(ingredientId) != null;
        }

        public bool UnitExists(int unitId)
        {
            return recipeContext.Units.Find(unitId) != null;
        }

        public bool IngredientsListItemExists(int itemId)
        {
            return recipeContext.IngredientsListItems.Find(itemId) != null;
        }

        public void DeleteIngredientsListItem(int itemId)
        {
            var entityToRemove = recipeContext.IngredientsListItems.Find(itemId);
            if (entityToRemove != null)
            {
                recipeContext.Remove(entityToRemove);
            }

            recipeContext.SaveChanges();
        }
    }
}