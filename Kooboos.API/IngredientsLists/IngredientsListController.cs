using Kooboos.API.IngredientsLists.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kooboos.API.IngredientsLists
{
    [ApiController]
    [Route("api/recipes/{recipeId}/ingredientslists")]
    public class IngredientsListController : ControllerBase
    {
        private readonly IIngredientsListService ingredientsListService;

        public IngredientsListController(IIngredientsListService ingredientsListService)
        {
            this.ingredientsListService = ingredientsListService;
        }

        [HttpGet(Name = "GetIngredientsList")]
        public IActionResult GetIngredientsList(int recipeId)
        {
            var ingredientsListDtos = ingredientsListService.GetByRecipeId(recipeId);
            if (ingredientsListDtos == null)
            {
                return NotFound();
            }

            return Ok(ingredientsListDtos);
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddIngredientsList(
            int recipeId,
            [FromBody] IngredientsListForCreationDto ingredientsListForCreationDto
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!ingredientsListService.RecipeExists(recipeId))
            {
                return NotFound();
            }

            var idOfNewIngredientsList = ingredientsListService.InsertIngredientsList(recipeId, ingredientsListForCreationDto);

            if (idOfNewIngredientsList > 0)
            {
                return CreatedAtRoute("GetIngredientsList", new { recipeId = recipeId }, ingredientsListForCreationDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("item")]
        public IActionResult AddIngredientsListItem(
            int recipeId,
            [FromBody] IngredientsListItemForCreationDto ingredientListItemForCreationDto)
        {
            if (!ModelState.IsValid
                    || !ingredientsListService.UnitExists(ingredientListItemForCreationDto.UnitId)
                    || !ingredientsListService.IngredientExists(ingredientListItemForCreationDto.IngredientId))
            {
                return BadRequest(ModelState);
            }

            if (!ingredientsListService.RecipeExists(recipeId))
            {
                return NotFound();
            }

            var idOfNewIngredientsListItem = ingredientsListService.InsertIngredientsListItem(recipeId, ingredientListItemForCreationDto);

            if (idOfNewIngredientsListItem > 0)
            {
                return CreatedAtRoute("GetIngredientsList", new { recipeId = recipeId }, ingredientListItemForCreationDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("item/{itemId}")]
        public IActionResult DeleteIngredientsListItem(int recipeId, int itemId)
        {
            if (!ingredientsListService.IngredientsListItemExists(itemId))
            {
                return NotFound();
            }

            ingredientsListService.DeleteIngredientsListItem(itemId);

            return NoContent();
        }
    }
}