using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class FurtherSchemaDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Test",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Test",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Test",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedAt",
                table: "Test",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Test",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Test",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Question",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedAt",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Question");
        }
    }
}
