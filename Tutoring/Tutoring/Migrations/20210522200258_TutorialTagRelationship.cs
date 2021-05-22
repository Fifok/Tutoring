using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring.Migrations
{
    public partial class TutorialTagRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorialTag",
                columns: table => new
                {
                    TutorialId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorialTag", x => new { x.TutorialId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TutorialTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorialTag_Tutorials_TutorialId",
                        column: x => x.TutorialId,
                        principalTable: "Tutorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorialTag_TagId",
                table: "TutorialTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutorialTag");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
