using Microsoft.EntityFrameworkCore.Migrations;

namespace Kooboos.API.Migrations
{
    public partial class Insertcompleterecipeastestinitialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Recipes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { null, "Auberginen" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { null, "Rosinen" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 15, null, "Basilikum" },
                    { 14, null, "Pinienkerne" },
                    { 13, null, "schwarzer Pfeffer" },
                    { 12, null, "Salz" },
                    { 11, null, "Kapern" },
                    { 16, null, "Ricotta salata" },
                    { 9, null, "Rotweinessig" },
                    { 10, null, "ganze Pelati" },
                    { 4, null, "Selleriestangen" },
                    { 5, null, "Olivenöl" },
                    { 3, null, "Zwiebel" },
                    { 7, null, "Oliven mit Stein" },
                    { 8, null, "Zucker" },
                    { 6, null, "Knoblauch" }
                });

            migrationBuilder.UpdateData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 400f);

            migrationBuilder.UpdateData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "UnitId" },
                values: new object[] { 35f, 1 });

            migrationBuilder.UpdateData(
                table: "IngredientsLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Caponata");

            migrationBuilder.InsertData(
                table: "IngredientsLists",
                columns: new[] { "Id", "RecipeId", "Title" },
                values: new object[] { 2, 1, "Zum Servieren" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Instruction", "Title" },
                values: new object[] { "Für die Caponata die Auberginene in 2 cm grosse Würfel schneiden und in ein Sieb geben. Mit Salz bestreuen und 30 Minuten stehen lassen. Die Rosinen 15 Minuten in warmem Wasser einweichen. Die Ziwebel halbieren und in Streifen schneiden. Die Selleriestangen längs halbieren und schräg in 2 cm grosse Stücke schneiden. In einer Pfanneetwas Olivenöl erhitzen, die Ziebel und den Sellerie zugeben, den Knoblauch dazupressen und alles bei mittlerer Hitze zugedeckt 10 Minuten dünsten, ohne dass das Gemüse Farbe annimmt.Die Oliven entsteinen und halbieren - dafür mit dem Boden eines Glases leicht auf jede Olive schlagen, den Stein aus dem aufgesprungenen Fleisch pulen und dieses halbieren. In einer grossen Bratpfanne grosszügig Olivenöl erhitzen, die Auberginenwürfel mit Küchenpapier trotcken tupfen und in zwei Durchgängen schön braun braten - sie sollen nicht zu weich werden. Den Zucker zum Sellerie geben, die Hitze aufdrehen, sodass der Zucker schmilzt, dann mit dem Rotweinessig ablöschen.Die Pelati von Hand zerdrücken und mit den Kapern, den Rosinen, den Oliven und den Auberginenwürfeln zum Sellerie geben, alles einmal aufkochen und dann bei schwacher Hitze 5 Minuten köcheln. Mit Salz und Pfeffer abschmecken und etwas abkühlen lassen.", "Cavatelli mit Caponata, Basilikum, Pinienkerne und Ricotta Salata" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "g");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Zehe");

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Stück" },
                    { 4, "TL" },
                    { 6, "Zweig" },
                    { 7, " " },
                    { 5, "dl" }
                });

            migrationBuilder.InsertData(
                table: "IngredientsListItems",
                columns: new[] { "Id", "IngredientId", "IngredientsListId", "Quantity", "UnitId" },
                values: new object[,]
                {
                    { 3, 3, 1, 1f, 2 },
                    { 4, 4, 1, 3f, 2 },
                    { 5, 5, 1, 1f, 2 },
                    { 7, 7, 1, 35f, 1 },
                    { 10, 10, 1, 150f, 1 },
                    { 11, 11, 1, 20f, 1 },
                    { 14, 14, 2, 60f, 1 },
                    { 6, 6, 1, 1f, 3 },
                    { 8, 8, 1, 1f, 4 },
                    { 9, 9, 1, 0.3f, 5 },
                    { 16, 15, 2, 4f, 6 },
                    { 12, 12, 1, 0f, 7 },
                    { 13, 13, 1, 0f, 7 },
                    { 15, 5, 2, 0f, 7 },
                    { 17, 16, 2, 0f, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "IngredientsLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Recipes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Spice up your life", "Black Pepper" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "For those who like it hot", "Hot Chili" });

            migrationBuilder.UpdateData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "IngredientsListItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "UnitId" },
                values: new object[] { 5f, 2 });

            migrationBuilder.UpdateData(
                table: "IngredientsLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Instruction", "Title" },
                values: new object[] { "Just some Instructions", "WTF Recipe" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Spoon");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Dash");
        }
    }
}
