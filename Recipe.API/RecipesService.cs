namespace Recipe.API
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository recipesRepository;

        public RecipesService(IRecipesRepository recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }
    }
}