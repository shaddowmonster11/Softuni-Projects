using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class dbInitialize7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeAssignments",
                table: "OfficeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_OfficeAssignments_InstructorId",
                table: "OfficeAssignments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OfficeAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeAssignments",
                table: "OfficeAssignments",
                column: "InstructorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeAssignments",
                table: "OfficeAssignments");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OfficeAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeAssignments",
                table: "OfficeAssignments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAssignments_InstructorId",
                table: "OfficeAssignments",
                column: "InstructorId",
                unique: true);
        }
    }
}
