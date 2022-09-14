using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class MIG1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ExamAssignments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExamAssignments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Enrollments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CourseAssignments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseAssignments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamAssignments_IsDeleted",
                table: "ExamAssignments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_IsDeleted",
                table: "Enrollments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_IsDeleted",
                table: "Departments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_IsDeleted",
                table: "CourseAssignments",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamAssignments_IsDeleted",
                table: "ExamAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_IsDeleted",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_IsDeleted",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignments_IsDeleted",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ExamAssignments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExamAssignments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseAssignments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");
        }
    }
}
