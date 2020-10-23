using System;
using AutoMapper;
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

        private readonly IMapper mapper;

        public IngredientsController(IIngredientsService ingredientsService, IMapper mapper)
        {
            this.ingredientsService = ingredientsService ?? throw new ArgumentNullException(nameof(ingredientsService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

            var ingredientDto = mapper.Map<IngredientDto>(ingredientForCreation);

            var idOfNewIngredient = ingredientsService.InsertIngredient(ingredientDto);

            if (idOfNewIngredient > 0)
            {
                ingredientDto.Id = idOfNewIngredient;
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

            var ingredientDtoWithNewValues = mapper.Map<IngredientDto>(ingredientForUpdateDto);

            ingredientsService.FullyUpdateIngredient(ingredientToUpdate, ingredientDtoWithNewValues);

            return NoContent();
        }
    }
}