using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.API.Entities
{
    public class Ingredient : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}