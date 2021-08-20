using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class InitialCreate37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "StudentExamAssigments",
                columns: table => new
                {
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamAssignmentsCourseId = table.Column<int>(type: "int", nullable: false),
                    ExamAssignmentsExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExamAssigments", x => new { x.StudentsId, x.ExamAssignmentsCourseId, x.ExamAssignmentsExamId });
                    table.ForeignKey(
                        name: "FK_StudentExamAssigments_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExamAssigments_ExamAssignments_ExamAssignmentsCourseId_ExamAssignmentsExamId",
                        columns: x => new { x.ExamAssignmentsCourseId, x.ExamAssignmentsExamId },
                        principalTable: "ExamAssignments",
                        principalColumns: new[] { "CourseId", "ExamId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamAssigments_ExamAssignmentsCourseId_ExamAssignmentsExamId",
                table: "StudentExamAssigments",
                columns: new[] { "ExamAssignmentsCourseId", "ExamAssignmentsExamId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExamAssigments");

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
    }
}
