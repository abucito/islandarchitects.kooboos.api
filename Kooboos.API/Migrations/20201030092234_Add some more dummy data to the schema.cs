using Microsoft.EntityFrameworkCore.Migrations;

namespace Kooboos.API.Migrations
{
    public partial class Addsomemoredummydatatotheschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Spice up your life");

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "For those who like it hot", "Hot Chili" });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Dash" });

            migrationBuilder.InsertData(
                table: "IngredientsListItems",
                columns: new[] { "Id", "IngredientId", "IngredientsListId", "Quantity", "UnitId" },
                values: new object[] { 2, 2, 1, 5f, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Spice up your life!");
        }
    }
}
