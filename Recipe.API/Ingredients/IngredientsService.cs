using System;
using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository ingredientsRepository;

        public IngredientsService(IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository ?? throw new ArgumentNullException(nameof(ingredientsRepository));
        }

        public IList<IngredientDto> GetIngredients()
        {
            return ingredientsRepository.GetIngredients();
        }

        public IngredientDto GetIngredient(int id)
        {
            return ingredientsRepository.GetIngredient(id);
        }

        public int InsertIngredient(IngredientDto ingredientDto)
        {
            var newIngredientId = ingredientsRepository.InsertIngredient(ingredientDto);
            ingredientsRepository.Save();
            return newIngredientId;
        }

        public void DeleteIngredient(IngredientDto ingredientToDelete)
        {
            ingredientsRepository.DeleteIngredient(ingredientToDelete);
            ingredientsRepository.Save();
        }

        public void FullyUpdateIngredient(IngredientDto ingredientToUpdate, IngredientDto ingredientDtoWithNewValues)
        {
            ingredientsRepository.UpdateIngredient(ingredientToUpdate, ingredientDtoWithNewValues);
            ingredientsRepository.Save();
        }
    }
}