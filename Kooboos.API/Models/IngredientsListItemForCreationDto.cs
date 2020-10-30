using System.ComponentModel.DataAnnotations;

namespace Kooboos.API.Models
{
    public class IngredientsListItemForCreationDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int IngredientId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int UnitId { get; set; }
    }
}