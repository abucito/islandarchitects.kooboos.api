using Microsoft.EntityFrameworkCore.Migrations;

namespace Kooboos.API.Migrations
{
    public partial class AddIngredientsListandIngredientsListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsList_Recipes_RecipeId",
                table: "IngredientsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsList",
                table: "IngredientsList");

            migrationBuilder.RenameTable(
                name: "IngredientsList",
                newName: "IngredientsLists");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsList_RecipeId",
                table: "IngredientsLists",
                newName: "IX_IngredientsLists_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsLists",
                table: "IngredientsLists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IngredientsListItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientsListId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Quantity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsListItems_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsListItems_IngredientsLists_IngredientsListId",
                        column: x => x.IngredientsListId,
                        principalTable: "IngredientsLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsListItems_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IngredientsLists",
                columns: new[] { "Id", "RecipeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "IngredientsListItems",
                columns: new[] { "Id", "IngredientId", "IngredientsListId", "Quantity", "UnitId" },
                values: new object[] { 1, 1, 1, 1f, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsListItems_IngredientId",
                table: "IngredientsListItems",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsListItems_IngredientsListId",
                table: "IngredientsListItems",
                column: "IngredientsListId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsListItems_UnitId",
                table: "IngredientsListItems",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsLists_Recipes_RecipeId",
                table: "IngredientsLists",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsLists_Recipes_RecipeId",
                table: "IngredientsLists");

            migrationBuilder.DropTable(
                name: "IngredientsListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsLists",
                table: "IngredientsLists");

            migrationBuilder.DeleteData(
                table: "IngredientsLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "IngredientsLists",
                newName: "IngredientsList");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsLists_RecipeId",
                table: "IngredientsList",
                newName: "IX_IngredientsList_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsList",
                table: "IngredientsList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsList_Recipes_RecipeId",
                table: "IngredientsList",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
