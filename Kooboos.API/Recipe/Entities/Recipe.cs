using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kooboos.API.Base;
using Kooboos.API.IngredientsLists.Entities;

namespace Kooboos.API.Recipes.Entities
{
    public class Recipe : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Instruction { get; set; }

        public ICollection<IngredientsList> IngredientsLists { get; set; } = new List<IngredientsList>();
    }
}