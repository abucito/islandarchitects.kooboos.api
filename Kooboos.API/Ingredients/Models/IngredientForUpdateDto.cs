using System.ComponentModel.DataAnnotations;

namespace Kooboos.API.Ingredients.Models
{
    public class IngredientForUpdateDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(50)]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}