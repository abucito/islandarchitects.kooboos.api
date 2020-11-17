using Microsoft.EntityFrameworkCore.Migrations;

namespace Kooboos.API.Migrations
{
    public partial class LetRecipeHaveMoreThanOneIngredientsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IngredientsLists_RecipeId",
                table: "IngredientsLists");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsLists_RecipeId",
                table: "IngredientsLists",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IngredientsLists_RecipeId",
                table: "IngredientsLists");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsLists_RecipeId",
                table: "IngredientsLists",
                column: "RecipeId",
                unique: true);
        }
    }
}
