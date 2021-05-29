using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring.Migrations
{
    public partial class AddMeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Tutorings_TutoringId",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Users_AuthorId",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Meeting_MeetingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MeetingId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Meeting",
                newName: "Meetings");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_TutoringId",
                table: "Meetings",
                newName: "IX_Meetings_TutoringId");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_AuthorId",
                table: "Meetings",
                newName: "IX_Meetings_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserMeeting",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeeting", x => new { x.UserId, x.MeetingId });
                    table.ForeignKey(
                        name: "FK_UserMeeting_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeeting_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_MeetingId",
                table: "UserMeeting",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Tutorings_TutoringId",
                table: "Meetings",
                column: "TutoringId",
                principalTable: "Tutorings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_AuthorId",
                table: "Meetings",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Tutorings_TutoringId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_AuthorId",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "UserMeeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings");

            migrationBuilder.RenameTable(
                name: "Meetings",
                newName: "Meeting");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_TutoringId",
                table: "Meeting",
                newName: "IX_Meeting_TutoringId");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_AuthorId",
                table: "Meeting",
                newName: "IX_Meeting_AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "MeetingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MeetingId",
                table: "Users",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Tutorings_TutoringId",
                table: "Meeting",
                column: "TutoringId",
                principalTable: "Tutorings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Users_AuthorId",
                table: "Meeting",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Meeting_MeetingId",
                table: "Users",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
