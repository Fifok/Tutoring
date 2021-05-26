using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring.Migrations
{
    public partial class AddPageNumberToPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "Page",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "Page");
        }
    }
}
