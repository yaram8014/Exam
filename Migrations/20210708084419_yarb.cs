using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Migrations
{
    public partial class yarb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Activityms",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Hm = table.Column<string>(nullable: true),
                    Dis = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activityms", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activityms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joins",
                columns: table => new
                {
                    RsvpId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    WeddingId = table.Column<int>(nullable: false),
                    JoinOfActivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joins", x => x.RsvpId);
                    table.ForeignKey(
                        name: "FK_Joins_Activityms_JoinOfActivityId",
                        column: x => x.JoinOfActivityId,
                        principalTable: "Activityms",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Joins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activityms_UserId",
                table: "Activityms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Joins_JoinOfActivityId",
                table: "Joins",
                column: "JoinOfActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Joins_UserId",
                table: "Joins",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Joins");

            migrationBuilder.DropTable(
                name: "Activityms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
