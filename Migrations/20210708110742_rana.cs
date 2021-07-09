using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Migrations
{
    public partial class rana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivitymId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivitymId",
                table: "Users");
        }
    }
}
