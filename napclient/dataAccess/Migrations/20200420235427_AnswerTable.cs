using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class AnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Text = table.Column<string>(type: "varchar(3000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(3000)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(3000)", nullable: true),
                    Type = table.Column<string>(type: "varchar(100)", nullable: true),
                    QuestionId = table.Column<string>(type: "char(36)", nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");
        }
    }
}
