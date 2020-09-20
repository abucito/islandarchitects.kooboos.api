using Microsoft.AspNetCore.Mvc;

namespace Recipe.API
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}