using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository ingredientsRepository;

        public IngredientsService(IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }

        public IList<IngredientDto> GetIngredients()
        {
            throw new System.NotImplementedException();
        }

        public IngredientDto GetIngredient(int validRecipeId)
        {
            throw new System.NotImplementedException();
        }

        public int InsertIngredient(IngredientDto ingredientDto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteIngredient(IngredientDto ingredientToDelete)
        {
            throw new System.NotImplementedException();
        }

        public void FullyUpdateIngredient(IngredientDto ingredientToUpdate, IngredientForUpdateDto ingredientForUpdateDto)
        {
            throw new System.NotImplementedException();
        }
    }
}