using Microsoft.EntityFrameworkCore.Migrations;

namespace Kooboos.API.Migrations
{
    public partial class AddUnitstoRecipeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsListItems_Unit_UnitId",
                table: "IngredientsListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsListItems_Units_UnitId",
                table: "IngredientsListItems",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsListItems_Units_UnitId",
                table: "IngredientsListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsListItems_Unit_UnitId",
                table: "IngredientsListItems",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
