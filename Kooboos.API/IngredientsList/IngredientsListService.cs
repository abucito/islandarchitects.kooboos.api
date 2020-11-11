using System;
using Kooboos.API.IngredientsLists.Models;

namespace Kooboos.API.IngredientsLists
{
    public class IngredientsListService : IIngredientsListService
    {
        private readonly IIngredientsListRepository ingredientsListRepository;

        public IngredientsListService(IIngredientsListRepository ingredientsListRepository)
        {
            this.ingredientsListRepository = ingredientsListRepository ?? throw new ArgumentNullException();
        }

        public IngredientsListDto GetByRecipeId(int recipeId)
        {
            var ingredientsListDto = ingredientsListRepository.GetByRecipeId(recipeId);
            var ingredientsListItemDtos = ingredientsListRepository.GetByIngredientsListId(ingredientsListDto.Id);

            foreach (var ingredientsListItemDto in ingredientsListItemDtos)
            {
                ingredientsListDto.IngredientsListItems.Add(ingredientsListItemDto);
            }

            return ingredientsListDto;
        }

        public int InsertIngredientsListItem(int recipeId, IngredientsListItemForCreationDto ingredientListItemForCreationDto)
        {
            return ingredientsListRepository.InsertIngredientsListItem(recipeId, ingredientListItemForCreationDto);
        }

        public bool RecipeExists(int recipeId)
        {
            return ingredientsListRepository.RecipeExits(recipeId);
        }

        public bool IngredientExists(int ingredientId)
        {
            return ingredientsListRepository.IngredientExists(ingredientId);
        }

        public bool UnitExists(int unitId)
        {
            return ingredientsListRepository.UnitExists(unitId);
        }

        public bool IngredientsListItemExists(int itemId)
        {
            return ingredientsListRepository.IngredientsListItemExists(itemId);
        }

        public void DeleteIngredientsListItem(int itemId)
        {
            ingredientsListRepository.DeleteIngredientsListItem(itemId);
        }
    }
}