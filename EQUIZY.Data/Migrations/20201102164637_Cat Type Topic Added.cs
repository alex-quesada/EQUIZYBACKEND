using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EQUIZY.Data.Migrations
{
    public partial class CatTypeTopicAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesEvaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopicsEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Topic = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicsEvaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopicsQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Topic = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicsQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesEvaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedById1 = table.Column<Guid>(nullable: false),
                    TypeEvaluationId = table.Column<int>(nullable: false),
                    CategoryEvaluationId = table.Column<int>(nullable: false),
                    TopicEvaluationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Rules = table.Column<string>(maxLength: 255, nullable: false),
                    Rating = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluation_CategoriesEvaluation_CategoryEvaluationId",
                        column: x => x.CategoryEvaluationId,
                        principalTable: "CategoriesEvaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_AspNetUsers_CreatedById1",
                        column: x => x.CreatedById1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_TopicsEvaluation_TopicEvaluationId",
                        column: x => x.TopicEvaluationId,
                        principalTable: "TopicsEvaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_TypesEvaluation_TypeEvaluationId",
                        column: x => x.TypeEvaluationId,
                        principalTable: "TypesEvaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedById1 = table.Column<Guid>(nullable: false),
                    TypeQuestionId = table.Column<int>(nullable: false),
                    CategoryQuestionId = table.Column<int>(nullable: false),
                    TopicQuestionId = table.Column<int>(nullable: false),
                    TimeToAnswer = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Rating = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestion_CategoriesQuestion_CategoryQuestionId",
                        column: x => x.CategoryQuestionId,
                        principalTable: "CategoriesQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestion_AspNetUsers_CreatedById1",
                        column: x => x.CreatedById1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestion_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestion_TopicsQuestion_TopicQuestionId",
                        column: x => x.TopicQuestionId,
                        principalTable: "TopicsQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestion_TypesQuestion_TypeQuestionId",
                        column: x => x.TypeQuestionId,
                        principalTable: "TypesQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnswerContent = table.Column<string>(nullable: true),
                    Correct = table.Column<byte>(nullable: false),
                    EvaluationQuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_EvaluationQuestion_EvaluationQuestionId",
                        column: x => x.EvaluationQuestionId,
                        principalTable: "EvaluationQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_EvaluationQuestionId",
                table: "Answer",
                column: "EvaluationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CategoryEvaluationId",
                table: "Evaluation",
                column: "CategoryEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CreatedById1",
                table: "Evaluation",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_TopicEvaluationId",
                table: "Evaluation",
                column: "TopicEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_TypeEvaluationId",
                table: "Evaluation",
                column: "TypeEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestion_CategoryQuestionId",
                table: "EvaluationQuestion",
                column: "CategoryQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestion_CreatedById1",
                table: "EvaluationQuestion",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestion_EvaluationId",
                table: "EvaluationQuestion",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestion_TopicQuestionId",
                table: "EvaluationQuestion",
                column: "TopicQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestion_TypeQuestionId",
                table: "EvaluationQuestion",
                column: "TypeQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "EvaluationQuestion");

            migrationBuilder.DropTable(
                name: "CategoriesQuestion");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "TopicsQuestion");

            migrationBuilder.DropTable(
                name: "TypesQuestion");

            migrationBuilder.DropTable(
                name: "CategoriesEvaluation");

            migrationBuilder.DropTable(
                name: "TopicsEvaluation");

            migrationBuilder.DropTable(
                name: "TypesEvaluation");
        }
    }
}
