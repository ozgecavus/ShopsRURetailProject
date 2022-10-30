using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUsRetail.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    IsRatePercentage = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    PayableAmount = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "StoreType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    IsPercantageDiscount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    UserType = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCost = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    ProductDiscountPrice = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    ProductPayableCost = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 1, true, "Affiliate Discount", 10m, "Affiliate" });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 2, true, "Employee Discount", 30m, "Employee" });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 3, true, "Loyal Customer Discount", 5m, "Customer" });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 4, false, "Price Discount", 5m, "Price" });

            migrationBuilder.InsertData(
                table: "StoreType",
                columns: new[] { "Id", "IsPercantageDiscount", "Name" },
                values: new object[] { 1, 0, "GROCERY" });

            migrationBuilder.InsertData(
                table: "StoreType",
                columns: new[] { "Id", "IsPercantageDiscount", "Name" },
                values: new object[] { 2, 1, "OTHER" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber", "UserType" },
                values: new object[] { 1, null, new DateTime(2019, 10, 23, 18, 7, 31, 572, DateTimeKind.Local).AddTicks(8035), "user1@email.com", "ozge", "cavus", "aksu", "123456789", "Customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber", "UserType" },
                values: new object[] { 2, null, new DateTime(2021, 10, 23, 18, 7, 31, 572, DateTimeKind.Local).AddTicks(8131), "user2@email.com", "simge", "aksu", "-", "123456789", "Affiliate" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber", "UserType" },
                values: new object[] { 3, null, new DateTime(2017, 10, 23, 18, 7, 31, 572, DateTimeKind.Local).AddTicks(8138), "user3@email.com", "Ahmet", "Cavus", null, "123456789", "Employee" });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountType");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "StoreType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
