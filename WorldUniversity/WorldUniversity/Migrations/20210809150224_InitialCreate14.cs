using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class InitialCreate14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_CourseId",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "CourseId", "InstructorId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignments",
                table: "CourseAssignments",
                columns: new[] { "Id", "InstructorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_CourseId",
                table: "CourseAssignments",
                column: "CourseId");
        }
    }
}
