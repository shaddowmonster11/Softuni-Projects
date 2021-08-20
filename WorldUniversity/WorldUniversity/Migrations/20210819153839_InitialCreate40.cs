using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class InitialCreate40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAssigments_ExamAssignments_ExamAssignmentsCourseId_ExamAssignmentsExamId",
                table: "StudentExamAssigments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExamAssigments",
                table: "StudentExamAssigments");

            migrationBuilder.DropIndex(
                name: "IX_StudentExamAssigments_ExamAssignmentsCourseId_ExamAssignmentsExamId",
                table: "StudentExamAssigments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamAssignments",
                table: "ExamAssignments");

            migrationBuilder.DropColumn(
                name: "ExamAssignmentsCourseId",
                table: "StudentExamAssigments");

            migrationBuilder.RenameColumn(
                name: "ExamAssignmentsExamId",
                table: "StudentExamAssigments",
                newName: "ExamAssignmentsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ExamAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExamAssigments",
                table: "StudentExamAssigments",
                columns: new[] { "ExamAssignmentsId", "StudentsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamAssignments",
                table: "ExamAssignments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamAssigments_StudentsId",
                table: "StudentExamAssigments",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAssignments_CourseId",
                table: "ExamAssignments",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAssigments_ExamAssignments_ExamAssignmentsId",
                table: "StudentExamAssigments",
                column: "ExamAssignmentsId",
                principalTable: "ExamAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAssigments_ExamAssignments_ExamAssignmentsId",
                table: "StudentExamAssigments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExamAssigments",
                table: "StudentExamAssigments");

            migrationBuilder.DropIndex(
                name: "IX_StudentExamAssigments_StudentsId",
                table: "StudentExamAssigments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamAssignments",
                table: "ExamAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ExamAssignments_CourseId",
                table: "ExamAssignments");

            migrationBuilder.RenameColumn(
                name: "ExamAssignmentsId",
                table: "StudentExamAssigments",
                newName: "ExamAssignmentsExamId");

            migrationBuilder.AddColumn<int>(
                name: "ExamAssignmentsCourseId",
                table: "StudentExamAssigments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ExamAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExamAssigments",
                table: "StudentExamAssigments",
                columns: new[] { "StudentsId", "ExamAssignmentsCourseId", "ExamAssignmentsExamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamAssignments",
                table: "ExamAssignments",
                columns: new[] { "CourseId", "ExamId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamAssigments_ExamAssignmentsCourseId_ExamAssignmentsExamId",
                table: "StudentExamAssigments",
                columns: new[] { "ExamAssignmentsCourseId", "ExamAssignmentsExamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAssigments_ExamAssignments_ExamAssignmentsCourseId_ExamAssignmentsExamId",
                table: "StudentExamAssigments",
                columns: new[] { "ExamAssignmentsCourseId", "ExamAssignmentsExamId" },
                principalTable: "ExamAssignments",
                principalColumns: new[] { "CourseId", "ExamId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
