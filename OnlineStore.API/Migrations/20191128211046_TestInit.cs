using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.API.Migrations
{
    public partial class TestInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeiveryMethod = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true),
                    IsTargeted = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    MinQuantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Balance = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    UserSurname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    DeliveryId = table.Column<int>(nullable: true),
                    PaymentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Delivery_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    SumOrder = table.Column<double>(nullable: false),
                    DateTimeOrder = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StringsOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringsOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringsOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StringsOrder_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "PhotoUrl" },
                values: new object[] { 1, "Таблички", "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "PhotoUrl" },
                values: new object[] { 2, "Покрывала", "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "PhotoUrl" },
                values: new object[] { 3, "Наволочки", "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "PhotoUrl" },
                values: new object[] { 4, "Рушники", "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "PhotoUrl" },
                values: new object[] { 5, "Салфетки", "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "PhotoUrl" },
                values: new object[] { 6, "Платки", "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "ColorName" },
                values: new object[] { 1, "Черный" });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "ColorName" },
                values: new object[] { 2, "Белый" });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "ColorName" },
                values: new object[] { 3, "Бордовый" });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "ColorName" },
                values: new object[] { 4, "Синий" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 1, 10, 1, 1, 7.5, "some", true, 10, "Табличка пластик 18х25" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 2, 10, 1, 1, 8.5, "some", true, 10, "Табличка пластик 20х25" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 3, 10, 1, 1, 11.0, "some", true, 10, "Табличка литьё" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 4, 10, 1, 2, 15.800000000000001, "some", true, 10, "Табличка металл" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 5, 10, 2, 2, 60.0, "some", true, 1, "Покрывало рюш шелк" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 7, 10, 3, 2, 27.5, "some", true, 10, "Наволочка жатка" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 8, 10, 4, 2, 32.5, "some", true, 10, "Рушник габардин 36" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Balance", "CategoryId", "ColorId", "Cost", "Description", "IsAvailable", "MinQuantity", "ProductName" },
                values: new object[] { 6, 10, 2, 3, 95.0, "some", true, 1, "Покрывало рюш атлас" });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "IsMain", "ProductId", "Url" },
                values: new object[] { 1, true, 1, "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "IsMain", "ProductId", "Url" },
                values: new object[] { 2, false, 1, "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "IsMain", "ProductId", "Url" },
                values: new object[] { 3, true, 2, "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "IsMain", "ProductId", "Url" },
                values: new object[] { 4, true, 3, "../../assets/img/candle.jpg" });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "IsMain", "ProductId", "Url" },
                values: new object[] { 5, true, 4, "../../assets/img/candle.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductId",
                table: "Photo",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ColorId",
                table: "Product",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_StringsOrder_OrderId",
                table: "StringsOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StringsOrder_ProductId",
                table: "StringsOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeliveryId",
                table: "Users",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PaymentId",
                table: "Users",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "StringsOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
