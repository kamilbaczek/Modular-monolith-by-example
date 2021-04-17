using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Products.DAL.Migrations
{
    public partial class init_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Products",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributePossibleValues",
                schema: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributePossibleValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributePossibleValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Products",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PossibleValue",
                schema: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PossibleValue_AttributePossibleValues_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Products",
                        principalTable: "AttributePossibleValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributePossibleValues_ProductId",
                schema: "Products",
                table: "AttributePossibleValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleValue_AttributeId",
                schema: "Products",
                table: "PossibleValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Products",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PossibleValue",
                schema: "Products");

            migrationBuilder.DropTable(
                name: "AttributePossibleValues",
                schema: "Products");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Products");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Products");
        }
    }
}
