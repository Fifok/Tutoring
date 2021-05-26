using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring.Migrations
{
    public partial class RemovePageFromDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Page_PageId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentItem_Page_PageId",
                table: "ContentItem");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PageId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "ContentItem",
                newName: "TutorialId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentItem_PageId",
                table: "ContentItem",
                newName: "IX_ContentItem_TutorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentItem_Tutorials_TutorialId",
                table: "ContentItem",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentItem_Tutorials_TutorialId",
                table: "ContentItem");

            migrationBuilder.RenameColumn(
                name: "TutorialId",
                table: "ContentItem",
                newName: "PageId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentItem_TutorialId",
                table: "ContentItem",
                newName: "IX_ContentItem_PageId");

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TutorialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_Tutorials_TutorialId",
                        column: x => x.TutorialId,
                        principalTable: "Tutorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PageId",
                table: "Comments",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_TutorialId",
                table: "Page",
                column: "TutorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Page_PageId",
                table: "Comments",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentItem_Page_PageId",
                table: "ContentItem",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
