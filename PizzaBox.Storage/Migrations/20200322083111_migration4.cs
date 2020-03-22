using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2020, 3, 21, 22, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 9L,
                column: "Date",
                value: new DateTime(2020, 3, 22, 6, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
