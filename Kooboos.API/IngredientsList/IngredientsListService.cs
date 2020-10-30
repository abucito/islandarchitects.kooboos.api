using System;

namespace Kooboos.API.IngredientsList
{
    public class IngredientsListService : IIngredientsListService
    {
        private readonly IIngredientsListRepository ingredientsListRepository;

        public IngredientsListService(IIngredientsListRepository ingredientsListRepository)
        {
            this.ingredientsListRepository = ingredientsListRepository ?? throw new ArgumentNullException();
        }
    }
}