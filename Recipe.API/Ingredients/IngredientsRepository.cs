using System.Collections.Generic;
using Recipe.API.Contexts;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly RecipeContext recipeContext;

        public IngredientsRepository(RecipeContext recipeContext)
        {
            this.recipeContext = recipeContext;
        }

        public IngredientDto GetIngredient(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<IngredientDto> GetIngredients()
        {
            throw new System.NotImplementedException();
        }

        public int InsertIngredient(IngredientDto ingredientDto)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateIngredient(IngredientDto ingredientToUpdate, IngredientForUpdateDto ingredientForUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteIngredient(IngredientDto ingredientDto)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}