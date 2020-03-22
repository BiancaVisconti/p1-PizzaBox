using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2020, 3, 22, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2020, 3, 19, 10, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
