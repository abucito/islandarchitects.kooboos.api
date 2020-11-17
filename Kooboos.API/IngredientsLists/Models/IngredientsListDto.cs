using System.Collections.Generic;

namespace Kooboos.API.IngredientsLists.Models
{
    public class IngredientsListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int RecipeId { get; set; }

        public ICollection<IngredientsListItemDto> IngredientsListItems { get; set; } = new List<IngredientsListItemDto>();
    }
}