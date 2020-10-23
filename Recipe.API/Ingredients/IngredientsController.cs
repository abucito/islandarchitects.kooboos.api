using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.API.Models;

namespace Recipe.API.Ingredients
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        [HttpGet]
        public IActionResult GetIngredients()
        {
            var ingredients = ingredientsService.GetIngredients();

            return Ok(ingredients);
        }

        [HttpGet("{id}", Name = "GetIngredient")]
        public IActionResult GetIngredient(int id)
        {
            var ingredient = ingredientsService.GetIngredient(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        [HttpPost]
        public IActionResult CreateIngredient(IngredientForCreationDto ingredientForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingredientDto = new IngredientDto
            {
                Name = ingredientForCreation.Name,
                Description = ingredientForCreation.Description
            };

            var idOfNewIngredient = ingredientsService.InsertIngredient(ingredientDto);

            if (idOfNewIngredient > 0)
            {
                return CreatedAtRoute("GetIngredient", new { Id = idOfNewIngredient }, ingredientDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIngredient(int id)
        {
            var ingredientToDelete = ingredientsService.GetIngredient(id);

            if (ingredientToDelete == null)
            {
                return NotFound();
            }

            ingredientsService.DeleteIngredient(ingredientToDelete);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult FullyUpdateIngredient(int id, IngredientForUpdateDto ingredientForUpdateDto)
        {
            var ingredientToUpdate = ingredientsService.GetIngredient(id);

            if (ingredientToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ingredientsService.FullyUpdateIngredient(ingredientToUpdate, ingredientForUpdateDto);

            return NoContent();
        }
    }
}