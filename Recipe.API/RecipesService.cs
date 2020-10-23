using System;
using System.Collections.Generic;
using Recipe.API.Models;

namespace Recipe.API
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository recipesRepository;

        public RecipesService(IRecipesRepository recipesRepository)
        {
            this.recipesRepository = recipesRepository ?? throw new ArgumentNullException();
        }

        public IList<RecipeDto> GetRecipes()
        {
            return recipesRepository.GetRecipes();
        }

        public RecipeDto GetRecipe(int id)
        {
            return recipesRepository.GetRecipe(id);
        }

        public int InsertRecipe(RecipeDto recipeDto)
        {
            var idOfNewRecipe = recipesRepository.InsertRecipe(recipeDto);
            recipesRepository.Save();
            return idOfNewRecipe;
        }

        public void DeleteRecipe(RecipeDto recipeToDelete)
        {
            recipesRepository.DeleteRecipe(recipeToDelete);
            recipesRepository.Save();
        }

        public void FullyUpdateRecipe(RecipeDto recipeToUpdate, RecipeDto recipeDtoWithNewValues)
        {
            recipesRepository.UpdateRecipe(recipeToUpdate, recipeDtoWithNewValues);
            recipesRepository.Save();
        }
    }
}