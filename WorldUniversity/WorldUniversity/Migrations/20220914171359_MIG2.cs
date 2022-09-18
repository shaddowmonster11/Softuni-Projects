using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldUniversity.Migrations
{
    public partial class MIG2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "OfficeAssignments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OfficeAssignments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Instructors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Instructors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAssignments_IsDeleted",
                table: "OfficeAssignments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_IsDeleted",
                table: "Instructors",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OfficeAssignments_IsDeleted",
                table: "OfficeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_IsDeleted",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "OfficeAssignments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OfficeAssignments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Instructors");
        }
    }
}
