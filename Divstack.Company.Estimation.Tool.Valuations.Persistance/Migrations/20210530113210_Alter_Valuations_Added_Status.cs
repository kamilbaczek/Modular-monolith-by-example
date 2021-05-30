using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Migrations
{
    public partial class Alter_Valuations_Added_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decision_RejectReason",
                schema: "Valuations",
                table: "Proposals");

            migrationBuilder.AddColumn<string>(
                name: "Status_Value",
                schema: "Valuations",
                table: "Valuations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Value",
                schema: "Valuations",
                table: "Valuations");

            migrationBuilder.AddColumn<string>(
                name: "Decision_RejectReason",
                schema: "Valuations",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
