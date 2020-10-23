using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Recipe.API.Contexts;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly RecipeContext recipeContext;

        private readonly IMapper mapper;

        public IngredientsRepository(RecipeContext recipeContext, IMapper mapper)
        {
            this.recipeContext = recipeContext ?? throw new ArgumentNullException(nameof(recipeContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IList<IngredientDto> GetIngredients()
        {
            return recipeContext.Ingredients.ToList().Select(i => mapper.Map<IngredientDto>(i)).ToList();
        }

        public IngredientDto GetIngredient(int id)
        {
            var ingredient = recipeContext.Ingredients.SingleOrDefault(i => i.Id == id);
            if (ingredient == null)
            {
                return null;
            }

            return mapper.Map<IngredientDto>(ingredient);
        }

        public int InsertIngredient(IngredientDto ingredientDto)
        {
            var ingredient = mapper.Map<Ingredient>(ingredientDto);
            recipeContext.Ingredients.Add(ingredient);
            return ingredient.Id;
        }

        public void UpdateIngredient(IngredientDto ingredientToUpdate, IngredientDto ingredientDtoWithNewValues)
        {
            var ingredient = recipeContext.Ingredients.SingleOrDefault(r => r.Id == ingredientToUpdate.Id);
            if (ingredient != null)
            {
                mapper.Map(ingredientDtoWithNewValues, ingredient);
            }
        }

        public void DeleteIngredient(IngredientDto ingredientDto)
        {
            var ingredientToRemove = recipeContext.Ingredients.SingleOrDefault(i => i.Id == ingredientDto.Id);
            if (ingredientToRemove != null)
            {
                recipeContext.Ingredients.Remove(ingredientToRemove);
            }
        }

        public void Save()
        {
            recipeContext.SaveChanges();
        }
    }
}