namespace Kooboos.API.Models
{
    public class IngredientsListItemDto
    {
        public int Id { get; set; }

        public string IngredientName { get; set; }

        public int Quantity { get; set; }

        public string UnitName { get; set; }
    }
}