using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class IsActive_column_fix_for_user_answers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Answer");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserTestRecord",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserTestRecord");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Answer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
