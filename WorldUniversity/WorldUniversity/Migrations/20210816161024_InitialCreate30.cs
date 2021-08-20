using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class InitialCreate30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ExamAssignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamAssignments_ApplicationUserId",
                table: "ExamAssignments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamAssignments_AspNetUsers_ApplicationUserId",
                table: "ExamAssignments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamAssignments_AspNetUsers_ApplicationUserId",
                table: "ExamAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ExamAssignments_ApplicationUserId",
                table: "ExamAssignments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ExamAssignments");
        }
    }
}
