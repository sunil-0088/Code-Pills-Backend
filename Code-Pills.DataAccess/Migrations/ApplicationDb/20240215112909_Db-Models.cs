using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code_Pills.DataAccess.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class DbModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prize1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prize2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prize3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attendees = table.Column<int>(type: "int", nullable: false),
                    Winner1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Winner2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Winner3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Submissions = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Shares = table.Column<int>(type: "int", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkilllName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContestUserMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestUserMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestUserMapping_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestUserMapping_PersonalInformation_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCredits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditsLeft = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attempts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceMapping_PersonalInformation_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestQuestionMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestQuestionMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestQuestionMapping_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestQuestionMapping_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestionMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestionMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestionMapping_PersonalInformation_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserQuestionMapping_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTagMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTagMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionTagMapping_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTagMapping_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestQuestionMapping_ContestId",
                table: "ContestQuestionMapping",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestQuestionMapping_QuestionId",
                table: "ContestQuestionMapping",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestUserMapping_ContestId",
                table: "ContestUserMapping",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestUserMapping_PersonalInfoId",
                table: "ContestUserMapping",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceMapping_PersonalInfoId",
                table: "PerformanceMapping",
                column: "PersonalInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTagMapping_QuestionId",
                table: "QuestionTagMapping",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTagMapping_TagId",
                table: "QuestionTagMapping",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionMapping_PersonalInfoId",
                table: "UserQuestionMapping",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionMapping_QuestionId",
                table: "UserQuestionMapping",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestQuestionMapping");

            migrationBuilder.DropTable(
                name: "ContestUserMapping");

            migrationBuilder.DropTable(
                name: "PerformanceMapping");

            migrationBuilder.DropTable(
                name: "QuestionTagMapping");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserQuestionMapping");

            migrationBuilder.DropTable(
                name: "Contests");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
