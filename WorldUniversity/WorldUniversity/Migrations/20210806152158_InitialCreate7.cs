using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "CourseAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "Id", "InstructorId", "ExamId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_ExamId",
                table: "CourseAssignments",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignments_Exams_ExamId",
                table: "CourseAssignments",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignments_Exams_ExamId",
                table: "CourseAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_ExamId",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "CourseAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "Id", "InstructorId" });
        }
    }
}
