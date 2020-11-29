using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EQUIZY.Data.Migrations
{
    public partial class QuizQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerList_QuizQuestion_QuizQuestionId",
                table: "AnswerList");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_EvaluationQuestion_EvaluationQuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuizQuestion_QuizQuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_CategoriesQuestion_CategoryQuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_CreatedById1",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_TopicsQuestion_TopicQuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_TypesQuestion_TypeQuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropTable(
                name: "EvaluationQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Answers_EvaluationQuestionId",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_CreatedById1",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "EvaluationQuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "QuizQuestion");

            migrationBuilder.RenameTable(
                name: "QuizQuestion",
                newName: "QuizQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestion_TypeQuestionId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_TypeQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestion_TopicQuestionId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_TopicQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestion_CategoryQuestionId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_CategoryQuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "QuizQuestions",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "QuizQuestions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvaluationId",
                table: "QuizQuestions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuestionList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EvaluationId = table.Column<int>(nullable: false),
                    QuizQuestionId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionList_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionList_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_CreatedById",
                table: "QuizQuestions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_EvaluationId",
                table: "QuizQuestions",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionList_EvaluationId",
                table: "QuestionList",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionList_QuizQuestionId",
                table: "QuestionList",
                column: "QuizQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerList_QuizQuestions_QuizQuestionId",
                table: "AnswerList",
                column: "QuizQuestionId",
                principalTable: "QuizQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuizQuestions_QuizQuestionId",
                table: "Answers",
                column: "QuizQuestionId",
                principalTable: "QuizQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_CategoriesQuestion_CategoryQuestionId",
                table: "QuizQuestions",
                column: "CategoryQuestionId",
                principalTable: "CategoriesQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_AspNetUsers_CreatedById",
                table: "QuizQuestions",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Evaluations_EvaluationId",
                table: "QuizQuestions",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_TopicsQuestion_TopicQuestionId",
                table: "QuizQuestions",
                column: "TopicQuestionId",
                principalTable: "TopicsQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_TypesQuestion_TypeQuestionId",
                table: "QuizQuestions",
                column: "TypeQuestionId",
                principalTable: "TypesQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerList_QuizQuestions_QuizQuestionId",
                table: "AnswerList");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuizQuestions_QuizQuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_CategoriesQuestion_CategoryQuestionId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_AspNetUsers_CreatedById",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Evaluations_EvaluationId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_TopicsQuestion_TopicQuestionId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_TypesQuestion_TypeQuestionId",
                table: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "QuestionList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_CreatedById",
                table: "QuizQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_EvaluationId",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "QuizQuestions");

            migrationBuilder.RenameTable(
                name: "QuizQuestions",
                newName: "QuizQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_TypeQuestionId",
                table: "QuizQuestion",
                newName: "IX_QuizQuestion_TypeQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_TopicQuestionId",
                table: "QuizQuestion",
                newName: "IX_QuizQuestion_TopicQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_CategoryQuestionId",
                table: "QuizQuestion",
                newName: "IX_QuizQuestion_CategoryQuestionId");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationQuestionId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "QuizQuestion",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "QuizQuestion",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById1",
                table: "QuizQuestion",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EvaluationQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryQuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedById1 = table.Column<Guid>(type: "char(36)", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    TimeToAnswer = table.Column<int>(type: "int", nullable: false),
                    TopicQuestionId = table.Column<int>(type: "int", nullable: false),
                    TypeQuestionId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_EvaluationQuestion_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
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

            migrationBuilder.CreateIndex(
                name: "IX_Answers_EvaluationQuestionId",
                table: "Answers",
                column: "EvaluationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_CreatedById1",
                table: "QuizQuestion",
                column: "CreatedById1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerList_QuizQuestion_QuizQuestionId",
                table: "AnswerList",
                column: "QuizQuestionId",
                principalTable: "QuizQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_EvaluationQuestion_EvaluationQuestionId",
                table: "Answers",
                column: "EvaluationQuestionId",
                principalTable: "EvaluationQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuizQuestion_QuizQuestionId",
                table: "Answers",
                column: "QuizQuestionId",
                principalTable: "QuizQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_CategoriesQuestion_CategoryQuestionId",
                table: "QuizQuestion",
                column: "CategoryQuestionId",
                principalTable: "CategoriesQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_CreatedById1",
                table: "QuizQuestion",
                column: "CreatedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_TopicsQuestion_TopicQuestionId",
                table: "QuizQuestion",
                column: "TopicQuestionId",
                principalTable: "TopicsQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_TypesQuestion_TypeQuestionId",
                table: "QuizQuestion",
                column: "TypeQuestionId",
                principalTable: "TypesQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
