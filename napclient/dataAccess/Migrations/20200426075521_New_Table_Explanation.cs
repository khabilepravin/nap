using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class New_Table_Explanation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Explanation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TextExplanation = table.Column<string>(type: "varchar(3000)", nullable: true),
                    ExternalLink = table.Column<string>(type: "varchar(3000)", nullable: true),
                    LinkType = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUser = table.Column<Guid>(type: "char(36)", nullable: false),
                    ModifiedByUser = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explanation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Explanation");
        }
    }
}
