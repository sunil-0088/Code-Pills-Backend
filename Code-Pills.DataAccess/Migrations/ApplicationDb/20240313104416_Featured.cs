using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code_Pills.DataAccess.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class Featured : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Featured",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PillCount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Featured", x => x.Id);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeaturedQuestionMappings");

            migrationBuilder.DropTable(
                name: "FeaturedUserMappings");

            migrationBuilder.DropTable(
                name: "Featured");
        }
    }
}
