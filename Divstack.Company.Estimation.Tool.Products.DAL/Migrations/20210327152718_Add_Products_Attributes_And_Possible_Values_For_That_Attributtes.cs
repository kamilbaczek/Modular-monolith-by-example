using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Products.DAL.Migrations
{
    public partial class Add_Products_Attributes_And_Possible_Values_For_That_Attributtes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "PossibleValue",
                column: "AttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PossibleValue");

            migrationBuilder.DropTable(
                name: "AttributePossibleValues",
                schema: "Products");
        }
    }
}
