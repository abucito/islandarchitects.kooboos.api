using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.API.Entities
{
    public class Recipe : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Instruction { get; set; }

        public IngredientsList IngredientsList { get; set; }
    }
}