using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kooboos.API.IngredientsLists.Models
{
    public class IngredientsListForCreationDto
    {
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; }

        public IList<IngredientsListItemForCreationDto> IngredientsListItems { get; set; }
    }
}