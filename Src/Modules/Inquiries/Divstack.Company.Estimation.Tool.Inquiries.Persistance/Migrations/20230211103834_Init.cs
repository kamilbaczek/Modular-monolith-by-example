using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Inquiries",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                ClientEmailValue = table.Column<string>(name: "Client_Email_Value", type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClientPhoneNumberValue = table.Column<string>(name: "Client_PhoneNumber_Value", type: "varchar(13)", maxLength: 13, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClientFirstName = table.Column<string>(name: "Client_FirstName", type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClientLastName = table.Column<string>(name: "Client_LastName", type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClientCompanySize = table.Column<string>(name: "Client_Company_Size", type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClientCompanyName = table.Column<string>(name: "Client_Company_Name", type: "longtext", nullable: false)
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
                ServiceServiceId = table.Column<Guid>(name: "Service_ServiceId", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                ValueId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
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

    /// <inheritdoc />
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
