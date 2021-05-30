using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Migrations
{
    public partial class Alter_Valuations_Removed_IsWaitingForDecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWaitingForDecision",
                schema: "Valuations",
                table: "Proposals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWaitingForDecision",
                schema: "Valuations",
                table: "Proposals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
