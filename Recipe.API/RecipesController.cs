using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.API.Models;

namespace Recipe.API
{
    // This should not be pushable
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

        [HttpGet("{id}", Name = "GetRecipe")]
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

            var recipeDto = new RecipeDto
            {
                Title = recipeForCreation.Title,
                Instruction = recipeForCreation.Instruction
            };

            var idOfNewRecipe = recipesService.InsertRecipe(recipeDto);

            if (idOfNewRecipe > 0)
            {
                return CreatedAtRoute("GetRecipe", new { Id = idOfNewRecipe }, recipeDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipeToDelete = recipesService.GetRecipe(id);

            if (recipeToDelete == null)
            {
                return NotFound();
            }

            recipesService.DeleteRecipe(recipeToDelete);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult FullyUpdateRecipe(int id, [FromBody] RecipeForUpdateDto recipeForUpdate)
        {
            var recipeToUpdate = recipesService.GetRecipe(id);

            if (recipeToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            recipesService.FullyUpdateRecipe(recipeToUpdate, recipeForUpdate);

            return NoContent();
        }
    }
}