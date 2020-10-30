using System;
using System.Linq;
using Kooboos.API.Models;

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
    }
}