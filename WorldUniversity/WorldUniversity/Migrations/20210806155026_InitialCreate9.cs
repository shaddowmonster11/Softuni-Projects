using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class InitialCreate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ExamAssignments",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAssignments", x => new { x.CourseId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamAssignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamAssignments_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamAssignments_ExamId",
                table: "ExamAssignments",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamAssignments");

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
    }
}
