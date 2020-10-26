using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.API.Entities
{
    public class IngredientsList : EntityBase
    {
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }

        public int RecipeId { get; set; }
    }
}