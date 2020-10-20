using System.Collections.Generic;
using Recipe.API.Contexts;
using Recipe.API.Models;
using System.Linq;

namespace Recipe.API
{
    public class RecipeRepository : IRecipesRepository
    {
        private readonly RecipeContext recipeContext;

        public RecipeRepository(RecipeContext recipeContext)
        {
            this.recipeContext = recipeContext;
        }

        public void DeleteRecipe(RecipeDto recipeDto)
        {
            var recipeToRemove = recipeContext.Recipes.SingleOrDefault(r => r.Id == recipeDto.Id);
            if (recipeToRemove != null)
            {
                recipeContext.Recipes.Remove(recipeToRemove);
            }
        }

        public RecipeDto GetRecipe(int id)
        {
            var recipe = recipeContext.Recipes.SingleOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return null;
            }
            else
            {
                return TranformToRecipeDto(recipe);
            }
        }

        private RecipeDto TranformToRecipeDto(Entities.Recipe recipe)
        {
            return new RecipeDto
            {
                Title = recipe.Title,
                Instruction = recipe.Instruction
            };
        }

        public IList<RecipeDto> GetRecipes()
        {
            var recipes = recipeContext.Recipes.ToList().Select(r => TranformToRecipeDto(r)).ToList();
            return recipes;
        }

        public int InsertRecipe(RecipeDto recipeDto)
        {
            var recipeToInsert = new Entities.Recipe
            {
                Title = recipeDto.Title,
                Instruction = recipeDto.Instruction
            };

            recipeContext.Recipes.Add(recipeToInsert);
            return recipeToInsert.Id;
        }

        public void Save()
        {
            recipeContext.SaveChanges();
        }

        public void UpdateRecipe(RecipeDto recipeToUpdate, RecipeForUpdateDto recipeForUpdate)
        {
            var recipe = recipeContext.Recipes.SingleOrDefault(r => r.Id == recipeToUpdate.Id);
            if (recipe != null)
            {
                recipe.Title = recipeForUpdate.Title;
                recipe.Instruction = recipeForUpdate.Instruction;
            }
        }
    }
}