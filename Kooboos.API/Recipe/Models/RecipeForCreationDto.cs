using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kooboos.API.Recipes.Models
{
    public class RecipeForCreationDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(50)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Instruction { get; set; }
    }
}