using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring.Migrations
{
    public partial class FixContentItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentItem",
                table: "ContentItem");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContentItem",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentItem",
                table: "ContentItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContentItem_PageId",
                table: "ContentItem",
                column: "PageId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentItem",
                table: "ContentItem");

            migrationBuilder.DropIndex(
                name: "IX_ContentItem_PageId",
                table: "ContentItem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContentItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentItem",
                table: "ContentItem",
                column: "PageId");
        }
    }
}
