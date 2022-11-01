using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class update_student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourse_courses_Courses1Id",
                table: "CategoryCourse");

            migrationBuilder.RenameColumn(
                name: "Courses1Id",
                table: "CategoryCourse",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryCourse_Courses1Id",
                table: "CategoryCourse",
                newName: "IX_CategoryCourse_CoursesId");

            migrationBuilder.AddColumn<int>(
                name: "edad",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourse_courses_CoursesId",
                table: "CategoryCourse",
                column: "CoursesId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourse_courses_CoursesId",
                table: "CategoryCourse");

            migrationBuilder.DropColumn(
                name: "edad",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CategoryCourse",
                newName: "Courses1Id");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryCourse_CoursesId",
                table: "CategoryCourse",
                newName: "IX_CategoryCourse_Courses1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourse_courses_Courses1Id",
                table: "CategoryCourse",
                column: "Courses1Id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
