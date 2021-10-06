using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeSubmissionSimple.Server.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonEmail = table.Column<string>(type: "TEXT", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerEntered = table.Column<string>(type: "TEXT", nullable: true),
                    Question = table.Column<string>(type: "TEXT", nullable: true),
                    SubmissionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Email", "PasswordHash", "Role" },
                values: new object[] { 1, "ashton@gmail.com", "1254wsde9632fgty", "Admin" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Email", "PasswordHash", "Role" },
                values: new object[] { 2, "hi@ngn.com", "1254wsdeu9632fgty", "Developer" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "DateCompleted", "PersonEmail" },
                values: new object[] { 1, new DateTime(2021, 9, 30, 13, 20, 6, 370, DateTimeKind.Local).AddTicks(5929), "test@test.com" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerEntered", "Question", "SubmissionId" },
                values: new object[] { 1, "ERD Answer", "Please see the attached ERD diagram image. The diagram was submitted as a solution to storing employee Cellphone data, voice and sms usage. Discuss at least one improvement that can be done to the ERD.", 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerEntered", "Question", "SubmissionId" },
                values: new object[] { 2, "Select * from Hello", "An analyst has asked you to run a query to see the number of movie tickets per genre that was sold in December last year.The data he needs is spread across two tables.", 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerEntered", "Question", "SubmissionId" },
                values: new object[] { 3, "Select * from Hello", "An analyst has asked you to run a query to see the number of movie tickets per genre that was sold in December last year.The data he needs is spread across two tables.", 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerEntered", "Question", "SubmissionId" },
                values: new object[] { 4, "Oh gosht this is long", "Write a C# method that will take, as input, a string and dependent on the string length prints out the following:\r\n\r\nIf the length is a multiple of 2 your method must print out \"Stack\"\r\nIf the length is a multiple of 4 your method must print out \"Overflow\"\r\nIf the length is a multiple of 2 and 4 your method must print out \"Stack Overflow!\" ", 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerEntered", "Question", "SubmissionId" },
                values: new object[] { 5, "SOme C# code", "This task is about code refactoring. Below you are given classes Animal, Horse and Sheep.\r\n\r\nYou need to refactor Horse and Sheep as you see fit.The goal is to make the classes more maintainable.You should apply any principles or patterns you think are necessary.\r\n\r\nDon\\'t make any change to the properties (methods) of the class Animal.", 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerEntered", "Question", "SubmissionId" },
                values: new object[] { 6, "document.getElementById...", "1. What will the colour of both div elements be?\r\n2. How would you dynamically target firstDiv and make it's colour pink? (provide the code snippet)\r\n3. How would you dynamically target secondDiv and add the yellow-card class to its class list? (provide the code snippet)", 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerEntered", "Question", "SubmissionId" },
                values: new object[] { 7, "Some Javascript work", "Why will the function be parsed correctly?\r\nHow could you introduce a stricter syntax to variable / function declaration and avoid this behaviour", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SubmissionId",
                table: "Answers",
                column: "SubmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "Submissions");
        }
    }
}
