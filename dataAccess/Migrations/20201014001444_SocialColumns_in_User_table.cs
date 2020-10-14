using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class SocialColumns_in_User_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SocialLoginId",
                table: "User",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialProfilePicUrl",
                table: "User",
                type: "varchar(3000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialLoginId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SocialProfilePicUrl",
                table: "User");
        }
    }
}
