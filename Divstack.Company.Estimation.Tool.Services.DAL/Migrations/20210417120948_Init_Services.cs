using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Services.DAL.Migrations
{
    public partial class Init_Services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Services");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Services",
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
                name: "Services",
                schema: "Services",
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
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Services",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributePossibleValues",
                schema: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributePossibleValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributePossibleValues_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Services",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PossibleValue",
                schema: "Services",
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
                        principalSchema: "Services",
                        principalTable: "AttributePossibleValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributePossibleValues_ServiceId",
                schema: "Services",
                table: "AttributePossibleValues",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleValue_AttributeId",
                schema: "Services",
                table: "PossibleValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                schema: "Services",
                table: "Services",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PossibleValue",
                schema: "Services");

            migrationBuilder.DropTable(
                name: "AttributePossibleValues",
                schema: "Services");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "Services");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Services");
        }
    }
}
