using Microsoft.EntityFrameworkCore.Migrations;

namespace dataAccess.Migrations
{
    public partial class GroupId_DataTypeFix_In_LookupValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupValue",
                table: "LookupValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupValue",
                table: "LookupValue",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupValue",
                table: "LookupValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupValue",
                table: "LookupValue",
                column: "GroupId");
        }
    }
}
