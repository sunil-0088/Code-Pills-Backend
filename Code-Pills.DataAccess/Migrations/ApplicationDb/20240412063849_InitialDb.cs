using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code_Pills.DataAccess.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
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
                    Winner3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWeekly = table.Column<bool>(type: "bit", nullable: false),
                    IsMonthly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Featured",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PillCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Featured", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
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
                    IsCompany = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOtp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOtp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContestUserMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestUserMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestUserMappings_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestUserMappings_PersonalInformation_UserId",
                        column: x => x.UserId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedUserMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedUserMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturedUserMappings_Featured_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Featured",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeaturedUserMappings_PersonalInformation_UserId",
                        column: x => x.UserId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCredits = table.Column<int>(type: "int", nullable: false),
                    CreditsLeft = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    Solved = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceMappings_PersonalInformation_UserId",
                        column: x => x.UserId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestQuestionMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestQuestionMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestQuestionMappings_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestQuestionMappings_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedQuestionMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedQuestionMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturedQuestionMappings_Featured_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Featured",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeaturedQuestionMappings_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestionMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestionMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestionMappings_PersonalInformation_UserId",
                        column: x => x.UserId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserQuestionMappings_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTagMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTagMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionTagMappings_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTagMappings_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestQuestionMappings_ContestId",
                table: "ContestQuestionMappings",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestQuestionMappings_QuestionId",
                table: "ContestQuestionMappings",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestUserMappings_ContestId",
                table: "ContestUserMappings",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestUserMappings_UserId",
                table: "ContestUserMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedQuestionMappings_FeatureId",
                table: "FeaturedQuestionMappings",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedQuestionMappings_QuestionId",
                table: "FeaturedQuestionMappings",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedUserMappings_FeatureId",
                table: "FeaturedUserMappings",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedUserMappings_UserId",
                table: "FeaturedUserMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceMappings_UserId",
                table: "PerformanceMappings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_Email",
                table: "PersonalInformation",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTagMappings_QuestionId",
                table: "QuestionTagMappings",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTagMappings_TagId",
                table: "QuestionTagMappings",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionMappings_QuestionId",
                table: "UserQuestionMappings",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionMappings_UserId",
                table: "UserQuestionMappings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestQuestionMappings");

            migrationBuilder.DropTable(
                name: "ContestUserMappings");

            migrationBuilder.DropTable(
                name: "FeaturedQuestionMappings");

            migrationBuilder.DropTable(
                name: "FeaturedUserMappings");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PerformanceMappings");

            migrationBuilder.DropTable(
                name: "QuestionTagMappings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserOtp");

            migrationBuilder.DropTable(
                name: "UserQuestionMappings");

            migrationBuilder.DropTable(
                name: "Contests");

            migrationBuilder.DropTable(
                name: "Featured");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
