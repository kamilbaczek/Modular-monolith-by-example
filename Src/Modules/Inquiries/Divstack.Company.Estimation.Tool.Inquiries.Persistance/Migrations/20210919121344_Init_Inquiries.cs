using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.Migrations
{
    public partial class Init_Inquiries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Client_Email_Value = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Client_FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Client_LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Client_Company_Size = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Client_Company_Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InquiryItemsServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Service_ServiceId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    InquiryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryItemsServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquiryItemsServices_Inquiries_InquiryId",
                        column: x => x.InquiryId,
                        principalTable: "Inquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InquiryItemsServicesAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServiceInquiryItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValueId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryItemsServicesAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquiryItemsServicesAttributes_InquiryItemsServices_ServiceI~",
                        column: x => x.ServiceInquiryItemId,
                        principalTable: "InquiryItemsServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryItemsServices_InquiryId",
                table: "InquiryItemsServices",
                column: "InquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryItemsServicesAttributes_ServiceInquiryItemId",
                table: "InquiryItemsServicesAttributes",
                column: "ServiceInquiryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InquiryItemsServicesAttributes");

            migrationBuilder.DropTable(
                name: "InquiryItemsServices");

            migrationBuilder.DropTable(
                name: "Inquiries");
        }
    }
}
