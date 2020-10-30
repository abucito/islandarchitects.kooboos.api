using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Kooboos.API.IngredientsLists
{
    [ApiController]
    [Route("api/recipes/{recipeId}/ingredientslist")]
    public class IngredientsListController : ControllerBase
    {
        private readonly IIngredientsListService ingredientsListService;

        private readonly IMapper mapper;

        public IngredientsListController(IIngredientsListService ingredientsListService, IMapper mapper)
        {
            this.ingredientsListService = ingredientsListService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetIngredientsList(int recipeId)
        {
            var ingredientsListDto = ingredientsListService.GetByRecipeId(recipeId);
            if (ingredientsListDto == null)
            {
                return NotFound();
            }

            return Ok(ingredientsListDto);
        }
    }
}