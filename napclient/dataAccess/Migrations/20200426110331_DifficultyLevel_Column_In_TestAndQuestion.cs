using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class DifficultyLevel_Column_In_TestAndQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "Test",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "Question",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "Question");
        }
    }
}
