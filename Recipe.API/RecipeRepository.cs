using System.Collections.Generic;
using Recipe.API.Contexts;
using Recipe.API.Models;
using System.Linq;
using AutoMapper;

namespace Recipe.API
{
    public class RecipeRepository : IRecipesRepository
    {
        private readonly RecipeContext recipeContext;

        private readonly IMapper mapper;

        public RecipeRepository(RecipeContext recipeContext, IMapper mapper)
        {
            this.recipeContext = recipeContext;
            this.mapper = mapper;
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
                var recipeDto = mapper.Map<RecipeDto>(mapper);
                return recipeDto;
            }
        }

        public IList<RecipeDto> GetRecipes()
        {
            var recipes = recipeContext.Recipes.ToList().Select(r => mapper.Map<RecipeDto>(r)).ToList();
            return recipes;
        }

        public int InsertRecipe(RecipeDto recipeDto)
        {
            var recipeToInsert = mapper.Map<Entities.Recipe>(recipeDto);
            recipeContext.Recipes.Add(recipeToInsert);
            return recipeToInsert.Id;
        }

        public void Save()
        {
            recipeContext.SaveChanges();
        }

        public void UpdateRecipe(RecipeDto recipeToUpdate, RecipeDto recipeDtoWithNewValues)
        {
            var recipe = recipeContext.Recipes.SingleOrDefault(r => r.Id == recipeToUpdate.Id);
            mapper.Map(recipeDtoWithNewValues, recipe);
        }
    }
}