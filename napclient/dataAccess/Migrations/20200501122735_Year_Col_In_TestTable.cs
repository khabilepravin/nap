using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class Year_Col_In_TestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Test",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Test");
        }
    }
}
