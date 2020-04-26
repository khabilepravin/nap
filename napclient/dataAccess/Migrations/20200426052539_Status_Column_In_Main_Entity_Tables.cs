using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class Status_Column_In_Main_Entity_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "User",
                type: "char(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Test",
                type: "char(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Question",
                type: "char(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Answer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Answer");
        }
    }
}
