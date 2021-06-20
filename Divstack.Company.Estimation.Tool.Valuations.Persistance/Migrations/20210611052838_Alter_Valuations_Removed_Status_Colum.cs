using Microsoft.EntityFrameworkCore.Migrations;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Migrations
{
    public partial class Alter_Valuations_Removed_Status_Colum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Value",
                schema: "Valuations",
                table: "Valuations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status_Value",
                schema: "Valuations",
                table: "Valuations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
