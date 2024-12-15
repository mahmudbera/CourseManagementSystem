using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId");
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassroomName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomId);
                    table.ForeignKey(
                        name: "FK_Classrooms_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Grade = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Email", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "johndoe@email.com", "John", new DateTime(2024, 12, 15, 3, 52, 29, 886, DateTimeKind.Local).AddTicks(6131), "Doe" },
                    { 2, "janesmith@email.com", "Jane", new DateTime(2024, 12, 15, 3, 52, 29, 886, DateTimeKind.Local).AddTicks(6139), "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "Email", "EnrollmentDate", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@email.com", new DateTime(2024, 12, 15, 3, 52, 29, 886, DateTimeKind.Local).AddTicks(7401), "Alice", "Johnson", "Active" },
                    { 2, new DateTime(2000, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@email.com", new DateTime(2024, 12, 15, 3, 52, 29, 886, DateTimeKind.Local).AddTicks(7408), "Bob", "Brown", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Credits", "Description", "InstructorId", "Status" },
                values: new object[,]
                {
                    { 1, "Math 101", 3, "Basic Mathematics", 1, "Active" },
                    { 2, "History 101", 3, "Basic History", 2, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "ClassroomId", "Capacity", "ClassroomName", "CourseId" },
                values: new object[,]
                {
                    { 1, 30, "Room A", 1 },
                    { 2, 25, "Room B", 2 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 15, 3, 52, 29, 886, DateTimeKind.Local).AddTicks(4948), null, 1 },
                    { 2, 2, new DateTime(2024, 12, 15, 3, 52, 29, 886, DateTimeKind.Local).AddTicks(4963), null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_CourseId",
                table: "Classrooms",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
