using System.ComponentModel.DataAnnotations;

namespace Recipe.API.Models
{
    public class UnitForCreationDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(50)]
        public string Name { get; set; }
    }
}