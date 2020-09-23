using System.Collections.Generic;

namespace Recipe.API.Models
{
    public class RecipeDTO
    {
        public string Title { get; set; }

        public string Instruction { get; set; }

        public IList<IngredientDto> ListOfIngredients { get; set; } = new List<IngredientDto>();

    }
}