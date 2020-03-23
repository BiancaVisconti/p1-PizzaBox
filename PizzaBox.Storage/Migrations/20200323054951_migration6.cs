using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2020, 3, 22, 22, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 1L,
                column: "Name",
                value: "Small Hawaiian Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 2L,
                column: "Name",
                value: "Medium Hawaiian Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 3L,
                column: "Name",
                value: "Large Hawaiian Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 4L,
                column: "Name",
                value: "Small Exquisite Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 5L,
                column: "Name",
                value: "Medium Exquisite Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 6L,
                column: "Name",
                value: "Large Exquisite Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 7L,
                column: "Name",
                value: "Small Delicious Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 8L,
                column: "Name",
                value: "Medium Delicious Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 9L,
                column: "Name",
                value: "Large Delicious Pizza");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 10L,
                column: "Name",
                value: "Giant Super Pizza");

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 1L,
                column: "Inventory",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 3L,
                column: "Inventory",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 5L,
                column: "Inventory",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 6L,
                column: "Inventory",
                value: 8);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 7L,
                column: "Inventory",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 8L,
                column: "Inventory",
                value: 9);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 11L,
                column: "Inventory",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 12L,
                column: "Inventory",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 13L,
                column: "Inventory",
                value: 7);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 14L,
                column: "Inventory",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 15L,
                column: "Inventory",
                value: 13);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 16L,
                column: "Inventory",
                value: 20);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 17L,
                column: "Inventory",
                value: 21);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 18L,
                column: "Inventory",
                value: 20);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 19L,
                column: "Inventory",
                value: 8);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 21L,
                column: "Inventory",
                value: 14);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 22L,
                column: "Inventory",
                value: 17);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 23L,
                column: "Inventory",
                value: 34);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 24L,
                column: "Inventory",
                value: 25);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 25L,
                column: "Inventory",
                value: 27);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 26L,
                column: "Inventory",
                value: 12);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 27L,
                column: "Inventory",
                value: 13);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 28L,
                column: "Inventory",
                value: 14);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 29L,
                column: "Inventory",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 30L,
                column: "Inventory",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 31L,
                column: "Inventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 32L,
                column: "Inventory",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 33L,
                column: "Inventory",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 34L,
                column: "Inventory",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 42L,
                column: "Inventory",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 43L,
                column: "Inventory",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 44L,
                column: "Inventory",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 45L,
                column: "Inventory",
                value: 7);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 47L,
                column: "Inventory",
                value: 9);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 48L,
                column: "Inventory",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 49L,
                column: "Inventory",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 51L,
                column: "Inventory",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 52L,
                column: "Inventory",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 53L,
                column: "Inventory",
                value: 7);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 54L,
                column: "Inventory",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 55L,
                column: "Inventory",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 58L,
                column: "Inventory",
                value: 7);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 59L,
                column: "Inventory",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2020, 3, 21, 22, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 1L,
                column: "Name",
                value: "SMALL HAWAIIAN PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 2L,
                column: "Name",
                value: "MEDIUM HAWAIIAN PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 3L,
                column: "Name",
                value: "LARGE HAWAIIAN PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 4L,
                column: "Name",
                value: "SMALL EXQUISITE PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 5L,
                column: "Name",
                value: "MEDIUM EXQUISITE PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 6L,
                column: "Name",
                value: "LARGE EXQUISITE PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 7L,
                column: "Name",
                value: "SMALL DELICIOUS PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 8L,
                column: "Name",
                value: "MEDIUM DELICIOUS PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 9L,
                column: "Name",
                value: "LARGE DELICIOUS PIZZA");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 10L,
                column: "Name",
                value: "GIANT SUPER PIZZA");

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 1L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 3L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 5L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 6L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 7L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 8L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 11L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 12L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 13L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 14L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 15L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 16L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 17L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 18L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 19L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 21L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 22L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 23L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 24L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 25L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 26L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 27L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 28L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 29L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 30L,
                column: "Inventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 31L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 32L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 33L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 34L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 42L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 43L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 44L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 45L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 47L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 48L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 49L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 51L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 52L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 53L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 54L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 55L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 58L,
                column: "Inventory",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StorePizza",
                keyColumn: "StorePizzaId",
                keyValue: 59L,
                column: "Inventory",
                value: 2);
        }
    }
}
