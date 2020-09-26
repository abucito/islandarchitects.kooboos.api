using System;
using Microsoft.AspNetCore.Mvc;
using Recipe.API.Models;

namespace Recipe.API
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService ?? throw new ArgumentNullException();
        }

        [HttpGet, Route("api/test")]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetRecipies()
        {
            var recipes = recipesService.GetRecipes();

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipe(int id)
        {
            var recipe = recipesService.GetRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public IActionResult CreateRecipe([FromBody] RecipeForCreationDto recipeForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created("", null);
        }
    }
}