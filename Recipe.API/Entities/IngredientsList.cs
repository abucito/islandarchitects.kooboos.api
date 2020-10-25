using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.API.Entities
{
    public class IngredientsList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }

        public int RecipeId { get; set; }
    }
}