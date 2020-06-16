using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageSchool.UI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbo.Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    TrainingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PeopleCount = table.Column<int>(nullable: false),
                    PurchesDate = table.Column<DateTime>(nullable: false),
                    TrainingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "TrainingTime", "Year" },
                values: new object[] { new Guid("3343be0f-8134-490c-9163-46358e1b4a77"), "Kurs Angielskiego A1", 350, 2019 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "TrainingTime", "Year" },
                values: new object[] { new Guid("cf92ef48-e040-4f01-9fd1-307da82ce559"), "Kurs Angielskiego B1", 450, 2019 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "TrainingTime", "Year" },
                values: new object[] { new Guid("265e0f96-e9e2-48ec-900d-d67283992990"), "Kurs Angielskiego C1", 550, 2019 });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Date", "CourseId" },
                values: new object[] { new Guid("ef473f01-f344-4470-8f1b-ab4637948fa6"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("3343be0f-8134-490c-9163-46358e1b4a77") });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Date", "CourseId" },
                values: new object[] { new Guid("ba628c2f-47e0-4340-bd65-2c84dedef60c"), new DateTime(2019, 3, 10, 22, 30, 0, 0, DateTimeKind.Unspecified), new Guid("cf92ef48-e040-4f01-9fd1-307da82ce559") });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Date", "CourseId" },
                values: new object[] { new Guid("ac287e1f-e8ed-4644-a983-2c8304a560e0"), new DateTime(2019, 4, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("265e0f96-e9e2-48ec-900d-d67283992990") });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CourseId",
                table: "Trainings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TrainingId",
                table: "Bookings",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
