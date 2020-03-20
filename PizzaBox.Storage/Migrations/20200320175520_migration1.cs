using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "StorePizza",
                columns: table => new
                {
                    StorePizzaId = table.Column<long>(nullable: false),
                    PizzaId = table.Column<long>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    Inventory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorePizza", x => x.StorePizzaId);
                    table.ForeignKey(
                        name: "FK_StorePizza_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorePizza_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    OrderPizzaId = table.Column<long>(nullable: false),
                    PizzaId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => x.OrderPizzaId);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", "SMALL HAWAIIAN PIZZA", 5.00m },
                    { 2L, "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", "MEDIUM HAWAIIAN PIZZA", 9.50m },
                    { 3L, "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", "LARGE HAWAIIAN PIZZA", 13.90m },
                    { 4L, "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", "SMALL EXQUISITE PIZZA", 6.00m },
                    { 5L, "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", "MEDIUM EXQUISITE PIZZA", 11.00m },
                    { 6L, "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", "LARGE EXQUISITE PIZZA", 15.50m },
                    { 7L, "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", "SMALL DELICIOUS PIZZA", 5.50m },
                    { 8L, "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", "MEDIUM DELICIOUS PIZZA", 10.50m },
                    { 9L, "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", "LARGE DELICIOUS PIZZA", 16.50m },
                    { 10L, "thick crust, tomato sauce, tomate, pineapple, avocado", "GIANT SUPER PIZZA", 59.90m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 6L, "Mesquite 87", "PizzaLover", "pizza" },
                    { 5L, "Cooper 132", "Mangiata", "comer" },
                    { 4L, "Abram 34", "TuPizza", "pizza" },
                    { 3L, "Mesquite 476", "MiPizza", "pizza" },
                    { 2L, "Mitchel 83", "DiegoPizza", "diego" },
                    { 1L, "Cooper 786", "PizzaEater", "eater" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 1L, "Central 960", "Bianca", "bianca" },
                    { 2L, "Street 4250", "Silvana", "silvana" },
                    { 3L, "Calle 13", "Macarena", "maca" },
                    { 4L, "3 Poniente", "Victoria", "vicky" },
                    { 5L, "Avenida Beio 15", "Rufuz", "beio" },
                    { 6L, "15 Norte", "NancyCastro", "nancy" },
                    { 7L, "Avenida Beio 15", "Jenny", "jenny" },
                    { 8L, "Blanca Estela 76", "Fernanda", "ferna" },
                    { 9L, "Los Pellines 950", "Francisca", "fran" },
                    { 10L, "Lomas de Montenar 1190", "Sofia", "sofia" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Date", "StoreId", "UserId" },
                values: new object[,]
                {
                    { 7L, new DateTime(2020, 2, 24, 12, 30, 0, 0, DateTimeKind.Unspecified), 5L, 10L },
                    { 1L, new DateTime(2019, 11, 1, 7, 9, 14, 0, DateTimeKind.Unspecified), 1L, 1L },
                    { 8L, new DateTime(2020, 3, 1, 14, 25, 0, 0, DateTimeKind.Unspecified), 4L, 1L },
                    { 2L, new DateTime(2019, 11, 17, 7, 9, 14, 0, DateTimeKind.Unspecified), 2L, 2L },
                    { 6L, new DateTime(2020, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, 9L },
                    { 5L, new DateTime(2019, 12, 31, 15, 9, 0, 0, DateTimeKind.Unspecified), 2L, 2L },
                    { 4L, new DateTime(2019, 12, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), 1L, 7L },
                    { 9L, new DateTime(2020, 3, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 3L, 8L },
                    { 3L, new DateTime(2019, 12, 5, 7, 9, 14, 0, DateTimeKind.Unspecified), 1L, 2L }
                });

            migrationBuilder.InsertData(
                table: "StorePizza",
                columns: new[] { "StorePizzaId", "Inventory", "PizzaId", "StoreId" },
                values: new object[,]
                {
                    { 37L, 2, 7L, 4L },
                    { 38L, 2, 8L, 4L },
                    { 39L, 2, 9L, 4L },
                    { 40L, 2, 10L, 4L },
                    { 41L, 2, 1L, 5L },
                    { 42L, 2, 2L, 5L },
                    { 43L, 2, 3L, 5L },
                    { 44L, 2, 4L, 5L },
                    { 45L, 2, 5L, 5L },
                    { 46L, 2, 6L, 5L },
                    { 47L, 2, 7L, 5L },
                    { 49L, 2, 9L, 5L },
                    { 50L, 2, 10L, 5L },
                    { 51L, 2, 1L, 6L },
                    { 36L, 2, 6L, 4L },
                    { 53L, 2, 3L, 6L },
                    { 54L, 2, 4L, 6L },
                    { 55L, 2, 5L, 6L },
                    { 56L, 2, 6L, 6L },
                    { 57L, 2, 7L, 6L },
                    { 58L, 2, 8L, 6L },
                    { 59L, 2, 9L, 6L },
                    { 60L, 2, 10L, 6L },
                    { 48L, 2, 8L, 5L },
                    { 52L, 2, 2L, 6L },
                    { 35L, 2, 5L, 4L },
                    { 33L, 2, 3L, 4L },
                    { 2L, 2, 2L, 1L },
                    { 3L, 2, 3L, 1L },
                    { 4L, 2, 4L, 1L },
                    { 5L, 2, 5L, 1L },
                    { 6L, 2, 6L, 1L },
                    { 7L, 2, 7L, 1L },
                    { 8L, 2, 8L, 1L },
                    { 9L, 2, 9L, 1L },
                    { 10L, 2, 10L, 1L },
                    { 11L, 2, 1L, 2L },
                    { 12L, 2, 2L, 2L },
                    { 13L, 2, 3L, 2L },
                    { 14L, 2, 4L, 2L },
                    { 15L, 2, 5L, 2L },
                    { 16L, 2, 6L, 2L },
                    { 17L, 2, 7L, 2L },
                    { 18L, 2, 8L, 2L },
                    { 32L, 2, 2L, 4L },
                    { 31L, 2, 1L, 4L },
                    { 30L, 2, 10L, 3L },
                    { 29L, 2, 9L, 3L },
                    { 28L, 2, 8L, 3L },
                    { 27L, 2, 7L, 3L },
                    { 34L, 2, 4L, 4L },
                    { 26L, 2, 6L, 3L },
                    { 24L, 2, 4L, 3L },
                    { 23L, 2, 3L, 3L },
                    { 22L, 2, 2L, 3L },
                    { 21L, 2, 1L, 3L },
                    { 20L, 2, 10L, 2L },
                    { 19L, 2, 9L, 2L },
                    { 25L, 2, 5L, 3L },
                    { 1L, 2, 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "OrderPizza",
                columns: new[] { "OrderPizzaId", "Amount", "OrderId", "PizzaId" },
                values: new object[,]
                {
                    { 1L, 2, 1L, 3L },
                    { 2L, 3, 1L, 5L },
                    { 11L, 3, 8L, 5L },
                    { 12L, 1, 8L, 1L },
                    { 3L, 1, 2L, 2L },
                    { 4L, 1, 3L, 4L },
                    { 6L, 1, 5L, 2L },
                    { 5L, 2, 4L, 6L },
                    { 13L, 2, 9L, 9L },
                    { 14L, 1, 9L, 7L },
                    { 7L, 3, 6L, 7L },
                    { 8L, 1, 6L, 8L },
                    { 9L, 7, 7L, 9L },
                    { 10L, 2, 7L, 6L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_OrderId",
                table: "OrderPizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzaId",
                table: "OrderPizza",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePizza_PizzaId",
                table: "StorePizza",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePizza_StoreId",
                table: "StorePizza",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "StorePizza");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
