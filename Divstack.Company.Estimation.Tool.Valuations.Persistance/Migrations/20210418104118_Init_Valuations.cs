using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Migrations
{
    public partial class Init_Valuations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Valuations");

            migrationBuilder.CreateTable(
                name: "Valuations",
                schema: "Valuations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enquiry_Client_Email_Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Enquiry_Client_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enquiry_Client_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InquiryServices",
                schema: "Valuations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnquiryValuationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquiryServices_Valuations_EnquiryValuationId",
                        column: x => x.EnquiryValuationId,
                        principalSchema: "Valuations",
                        principalTable: "Valuations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                schema: "Valuations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description_Message = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Price_Value = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    Price_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuggestedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Suggested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelledBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cancelled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Decision_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Decision_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decision_RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Valuations_ValuationId",
                        column: x => x.ValuationId,
                        principalSchema: "Valuations",
                        principalTable: "Valuations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InquiryServices_EnquiryValuationId",
                schema: "Valuations",
                table: "InquiryServices",
                column: "EnquiryValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ValuationId",
                schema: "Valuations",
                table: "Proposals",
                column: "ValuationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InquiryServices",
                schema: "Valuations");

            migrationBuilder.DropTable(
                name: "Proposals",
                schema: "Valuations");

            migrationBuilder.DropTable(
                name: "Valuations",
                schema: "Valuations");
        }
    }
}
