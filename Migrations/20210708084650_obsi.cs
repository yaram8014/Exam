using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Migrations
{
    public partial class obsi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joins_Activityms_JoinOfActivityId",
                table: "Joins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Joins",
                table: "Joins");

            migrationBuilder.DropIndex(
                name: "IX_Joins_JoinOfActivityId",
                table: "Joins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activityms",
                table: "Activityms");

            migrationBuilder.DropColumn(
                name: "RsvpId",
                table: "Joins");

            migrationBuilder.DropColumn(
                name: "JoinOfActivityId",
                table: "Joins");

            migrationBuilder.DropColumn(
                name: "WeddingId",
                table: "Joins");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Activityms");

            migrationBuilder.AddColumn<int>(
                name: "JoinId",
                table: "Joins",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ActivitymId",
                table: "Joins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivitymId",
                table: "Activityms",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Joins",
                table: "Joins",
                column: "JoinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activityms",
                table: "Activityms",
                column: "ActivitymId");

            migrationBuilder.CreateIndex(
                name: "IX_Joins_ActivitymId",
                table: "Joins",
                column: "ActivitymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Joins_Activityms_ActivitymId",
                table: "Joins",
                column: "ActivitymId",
                principalTable: "Activityms",
                principalColumn: "ActivitymId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joins_Activityms_ActivitymId",
                table: "Joins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Joins",
                table: "Joins");

            migrationBuilder.DropIndex(
                name: "IX_Joins_ActivitymId",
                table: "Joins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activityms",
                table: "Activityms");

            migrationBuilder.DropColumn(
                name: "JoinId",
                table: "Joins");

            migrationBuilder.DropColumn(
                name: "ActivitymId",
                table: "Joins");

            migrationBuilder.DropColumn(
                name: "ActivitymId",
                table: "Activityms");

            migrationBuilder.AddColumn<int>(
                name: "RsvpId",
                table: "Joins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "JoinOfActivityId",
                table: "Joins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeddingId",
                table: "Joins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Activityms",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Joins",
                table: "Joins",
                column: "RsvpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activityms",
                table: "Activityms",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Joins_JoinOfActivityId",
                table: "Joins",
                column: "JoinOfActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Joins_Activityms_JoinOfActivityId",
                table: "Joins",
                column: "JoinOfActivityId",
                principalTable: "Activityms",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
