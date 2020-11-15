using System;
using AutoMapper;
using Kooboos.API.Recipes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kooboos.API.Recipes
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService recipesService;

        private readonly IMapper mapper;

        public RecipesController(IRecipesService recipesService, IMapper mapper)
        {
            this.recipesService = recipesService ?? throw new ArgumentNullException(nameof(recipesService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetRecipes()
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

            var recipeDto = mapper.Map<RecipeDto>(recipeForCreation);
            var idOfNewRecipe = recipesService.InsertRecipe(recipeDto);

            if (idOfNewRecipe > 0)
            {
                recipeDto.Id = idOfNewRecipe;
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

            var recipeDtoWithNewValues = mapper.Map<RecipeDto>(recipeForUpdate);

            recipesService.FullyUpdateRecipe(recipeToUpdate, recipeDtoWithNewValues);

            return NoContent();
        }
    }
}