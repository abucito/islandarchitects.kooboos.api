namespace Kooboos.API.Models
{
    public class IngredientsListItemDto
    {

        public int Id { get; set; }

        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public int Quantity { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; }
    }
}