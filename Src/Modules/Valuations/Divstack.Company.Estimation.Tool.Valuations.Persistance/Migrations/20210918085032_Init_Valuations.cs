using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Migrations
{
    public partial class Init_Valuations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Valuations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InquiryId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RequestedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompletedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Deadline_Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description_Message = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price_Value = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    Price_Currency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SuggestedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Suggested = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CancelledBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Cancelled = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Decision_Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Decision_Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValuationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Valuations_ValuationId",
                        column: x => x.ValuationId,
                        principalTable: "Valuations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ValuationsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValuationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status_Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuationsHistory_Valuations_ValuationId",
                        column: x => x.ValuationId,
                        principalTable: "Valuations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ValuationId",
                table: "Proposals",
                column: "ValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationsHistory_ValuationId",
                table: "ValuationsHistory",
                column: "ValuationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "ValuationsHistory");

            migrationBuilder.DropTable(
                name: "Valuations");
        }
    }
}
