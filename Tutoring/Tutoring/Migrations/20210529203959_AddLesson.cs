using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring.Migrations
{
    public partial class AddLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentItem_Tutorials_TutorialId",
                table: "ContentItem");

            migrationBuilder.AlterColumn<int>(
                name: "TutorialId",
                table: "ContentItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "ContentItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    TutoringId = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Tutorings_TutoringId",
                        column: x => x.TutoringId,
                        principalTable: "Tutorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lesson_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentItem_LessonId",
                table: "ContentItem",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_AuthorId",
                table: "Lesson",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_TutoringId",
                table: "Lesson",
                column: "TutoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentItem_Lesson_LessonId",
                table: "ContentItem",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentItem_Tutorials_TutorialId",
                table: "ContentItem",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentItem_Lesson_LessonId",
                table: "ContentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentItem_Tutorials_TutorialId",
                table: "ContentItem");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_ContentItem_LessonId",
                table: "ContentItem");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "ContentItem");

            migrationBuilder.AlterColumn<int>(
                name: "TutorialId",
                table: "ContentItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentItem_Tutorials_TutorialId",
                table: "ContentItem",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
