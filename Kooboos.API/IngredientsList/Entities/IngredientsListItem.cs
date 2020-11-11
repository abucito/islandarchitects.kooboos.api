using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kooboos.API.Base;
using Kooboos.API.Ingredients.Entities;
using Kooboos.API.Units.Entities;

namespace Kooboos.API.IngredientsLists.Entities
{
    public class IngredientsListItem : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("IngredientsListId")]
        public IngredientsList IngredientsList { get; set; }

        public int IngredientsListId { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        public int UnitId { get; set; }

        [Required]
        [Range(float.Epsilon, float.MaxValue)]
        public float Quantity { get; set; }
    }
}