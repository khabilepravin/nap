using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class UserTestRecord_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTestRecord",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserTestId = table.Column<string>(type: "char(36)", nullable: true),
                    QuestionId = table.Column<string>(type: "char(36)", nullable: true),
                    AnswerId = table.Column<string>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTestRecord");
        }
    }
}
