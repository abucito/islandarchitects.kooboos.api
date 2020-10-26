using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.API.Entities
{
    public class Unit : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}