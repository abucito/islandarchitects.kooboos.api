using Microsoft.AspNetCore.Mvc;

namespace Kooboos.API.IngredientsList
{
    [ApiController]
    [Route("api/recipes/{recipeId}/ingredientslist")]
    public class IngredientsListController : ControllerBase
    {
        private readonly IIngredientsListService ingredientsListService;

        public IngredientsListController(IIngredientsListService ingredientsListService)
        {
            this.ingredientsListService = ingredientsListService;
        }

        [HttpGet]
        public IActionResult GetIngredientsList(int recipeId)
        {
            return Ok();
        }
    }
}