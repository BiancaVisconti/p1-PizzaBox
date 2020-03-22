using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 10L,
                column: "Inventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 20L,
                column: "Inventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 30L,
                column: "Inventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 40L,
                column: "Inventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 50L,
                column: "Inventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 60L,
                column: "Inventory",
                value: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 10L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 20L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 30L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 40L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 50L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 60L,
                column: "Inventory",
                value: 2);
        }
    }
}
