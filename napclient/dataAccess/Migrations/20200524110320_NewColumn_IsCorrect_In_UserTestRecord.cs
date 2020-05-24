using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class NewColumn_IsCorrect_In_UserTestRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "UserTestRecord",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "UserTestRecord");
        }
    }
}
