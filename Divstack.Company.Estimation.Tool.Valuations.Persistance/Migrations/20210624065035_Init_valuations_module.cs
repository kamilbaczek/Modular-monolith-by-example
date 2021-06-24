using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Migrations
{
    public partial class Init_valuations_module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valuations",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Enquiry_Client_Email_Value = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Enquiry_Client_FirstName = table.Column<string>(type: "text", nullable: true),
                    Enquiry_Client_LastName = table.Column<string>(type: "text", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompletedBy = table.Column<Guid>(type: "varbinary(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ValuationId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Status_Value = table.Column<string>(type: "text", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Valuations_ValuationId",
                        column: x => x.ValuationId,
                        principalTable: "Valuations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InquiryServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "varbinary(16)", nullable: false),
                    ServiceId = table.Column<Guid>(type: "varbinary(16)", nullable: true),
                    EnquiryValuationId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquiryServices_Valuations_EnquiryValuationId",
                        column: x => x.EnquiryValuationId,
                        principalTable: "Valuations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "varbinary(16)", nullable: false),
                    Description_Message = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    Price_Value = table.Column<decimal>(type: "decimal(18, 2)", precision: 15, scale: 2, nullable: true),
                    Price_Currency = table.Column<string>(type: "text", nullable: true),
                    SuggestedBy = table.Column<Guid>(type: "varbinary(16)", nullable: false),
                    Suggested = table.Column<DateTime>(type: "datetime", nullable: false),
                    CancelledBy = table.Column<Guid>(type: "varbinary(16)", nullable: true),
                    Cancelled = table.Column<DateTime>(type: "datetime", nullable: true),
                    Decision_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Decision_Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ValuationId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_ValuationId",
                table: "History",
                column: "ValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryServices_EnquiryValuationId",
                table: "InquiryServices",
                column: "EnquiryValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ValuationId",
                table: "Proposals",
                column: "ValuationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "InquiryServices");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Valuations");
        }
    }
}
