using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class relacion_User_baseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourse_categories_CategoriesId",
                table: "CategoryCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourse_courses_Courses1Id",
                table: "CategoryCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_courses_coursesId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_students_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "index");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "BaseEntity");

            migrationBuilder.RenameColumn(
                name: "Courses1Id",
                table: "CategoryCourse",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryCourse_Courses1Id",
                table: "CategoryCourse",
                newName: "IX_CategoryCourse_CoursesId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "BaseEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameCategory",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "courseName",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastNameStudent",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longCourseDescription",
                table: "BaseEntity",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "objectives",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shortCourseDescription",
                table: "BaseEntity",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "studentName",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "targetPublic",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BaseEntityUser",
                columns: table => new
                {
                    BentityId = table.Column<int>(type: "int", nullable: false),
                    usersBEId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntityUser", x => new { x.BentityId, x.usersBEId });
                    table.ForeignKey(
                        name: "FK_BaseEntityUser_BaseEntity_BentityId",
                        column: x => x.BentityId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntityUser_BaseEntity_usersBEId",
                        column: x => x.usersBEId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CourseId",
                table: "BaseEntity",
                column: "CourseId",
                unique: true,
                filter: "[CourseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntityUser_usersBEId",
                table: "BaseEntityUser",
                column: "usersBEId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_CourseId",
                table: "BaseEntity",
                column: "CourseId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourse_BaseEntity_CategoriesId",
                table: "CategoryCourse",
                column: "CategoriesId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourse_BaseEntity_CoursesId",
                table: "CategoryCourse",
                column: "CoursesId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_BaseEntity_coursesId",
                table: "CourseStudent",
                column: "coursesId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_BaseEntity_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_CourseId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourse_BaseEntity_CategoriesId",
                table: "CategoryCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourse_BaseEntity_CoursesId",
                table: "CategoryCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_BaseEntity_coursesId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_BaseEntity_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropTable(
                name: "BaseEntityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_CourseId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "NameCategory",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "courseName",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "lastNameStudent",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "longCourseDescription",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "objectives",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "shortCourseDescription",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "studentName",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "targetPublic",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CategoryCourse",
                newName: "Courses1Id");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryCourse_CoursesId",
                table: "CategoryCourse",
                newName: "IX_CategoryCourse_Courses1Id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    longCourseDescription = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    objectives = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    shortCourseDescription = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
                    targetPublic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastNameStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "index",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_index", x => x.Id);
                    table.ForeignKey(
                        name: "FK_index_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_index_CourseId",
                table: "index",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourse_categories_CategoriesId",
                table: "CategoryCourse",
                column: "CategoriesId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourse_courses_Courses1Id",
                table: "CategoryCourse",
                column: "Courses1Id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_courses_coursesId",
                table: "CourseStudent",
                column: "coursesId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_students_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
