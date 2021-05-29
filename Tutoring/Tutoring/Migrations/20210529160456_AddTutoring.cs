using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring.Migrations
{
    public partial class AddTutoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tutorings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutorings_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoringId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Tutorings_TutoringId",
                        column: x => x.TutoringId,
                        principalTable: "Tutorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTutoring",
                columns: table => new
                {
                    TutoringId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTutoring", x => new { x.TutoringId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentTutoring_Tutorings_TutoringId",
                        column: x => x.TutoringId,
                        principalTable: "Tutorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTutoring_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MeetingId",
                table: "Users",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_AuthorId",
                table: "Meeting",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_TutoringId",
                table: "Meeting",
                column: "TutoringId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTutoring_StudentId",
                table: "StudentTutoring",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorings_TeacherId",
                table: "Tutorings",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Meeting_MeetingId",
                table: "Users",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Meeting_MeetingId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "StudentTutoring");

            migrationBuilder.DropTable(
                name: "Tutorings");

            migrationBuilder.DropIndex(
                name: "IX_Users_MeetingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Users");
        }
    }
}
