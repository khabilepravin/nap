using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class ForSqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(type: "varchar(3000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(3000)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(3000)", nullable: true),
                    Type = table.Column<string>(type: "varchar(100)", nullable: true),
                    QuestionId = table.Column<string>(type: "char(36)", nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Explanation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<string>(type: "char(36)", nullable: false),
                    TextExplanation = table.Column<string>(type: "varchar(3000)", nullable: true),
                    ExternalLink = table.Column<string>(type: "varchar(3000)", nullable: true),
                    LinkType = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUser = table.Column<string>(type: "char(36)", nullable: false),
                    ModifiedByUser = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explanation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Code = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Code = table.Column<string>(type: "varchar(30)", nullable: true),
                    GroupId = table.Column<string>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(type: "varchar(3000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(3000)", nullable: true),
                    QuestionType = table.Column<string>(nullable: true),
                    TestId = table.Column<string>(type: "char(36)", nullable: false),
                    Sequence = table.Column<short>(nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(3000)", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUser = table.Column<string>(type: "char(36)", nullable: false),
                    ModifiedByUser = table.Column<string>(type: "char(36)", nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    DifficultyLevel = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Sequence = table.Column<short>(nullable: false),
                    Subject = table.Column<string>(type: "varchar(100)", nullable: true),
                    DurationMinutes = table.Column<short>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedByUser = table.Column<string>(type: "char(36)", nullable: false),
                    ModifiedByUser = table.Column<string>(type: "char(36)", nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    DifficultyLevel = table.Column<string>(type: "varchar(100)", nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserType = table.Column<string>(type: "varchar(100)", nullable: true),
                    Password = table.Column<string>(type: "varchar(500)", nullable: true),
                    ParentUserId = table.Column<string>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(type: "char(36)", nullable: false),
                    TestId = table.Column<string>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTestRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserTestId = table.Column<string>(type: "char(36)", nullable: false),
                    QuestionId = table.Column<string>(type: "char(36)", nullable: false),
                    AnswerId = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Explanation");

            migrationBuilder.DropTable(
                name: "LookupGroup");

            migrationBuilder.DropTable(
                name: "LookupValue");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserTest");

            migrationBuilder.DropTable(
                name: "UserTestRecord");
        }
    }
}
