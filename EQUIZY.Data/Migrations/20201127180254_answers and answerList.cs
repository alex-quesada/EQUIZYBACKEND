using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EQUIZY.Data.Migrations
{
    public partial class answersandanswerList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_EvaluationQuestion_EvaluationQuestionId",
                table: "Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_EvaluationQuestionId",
                table: "Answers",
                newName: "IX_Answers_EvaluationQuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerContent",
                table: "Answers",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuizQuestionId",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Answers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuizQuestion",
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
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_CategoriesQuestion_CategoryQuestionId",
                        column: x => x.CategoryQuestionId,
                        principalTable: "CategoriesQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_AspNetUsers_CreatedById1",
                        column: x => x.CreatedById1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_TopicsQuestion_TopicQuestionId",
                        column: x => x.TopicQuestionId,
                        principalTable: "TopicsQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_TypesQuestion_TypeQuestionId",
                        column: x => x.TypeQuestionId,
                        principalTable: "TypesQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuizQuestionId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerList_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerList_QuizQuestion_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuizQuestionId",
                table: "Answers",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerList_AnswerId",
                table: "AnswerList",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerList_QuizQuestionId",
                table: "AnswerList",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_CategoryQuestionId",
                table: "QuizQuestion",
                column: "CategoryQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_CreatedById1",
                table: "QuizQuestion",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_TopicQuestionId",
                table: "QuizQuestion",
                column: "TopicQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_TypeQuestionId",
                table: "QuizQuestion",
                column: "TypeQuestionId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_EvaluationQuestion_EvaluationQuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuizQuestion_QuizQuestionId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "AnswerList");

            migrationBuilder.DropTable(
                name: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuizQuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuizQuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_EvaluationQuestionId",
                table: "Answer",
                newName: "IX_Answer_EvaluationQuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerContent",
                table: "Answer",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_EvaluationQuestion_EvaluationQuestionId",
                table: "Answer",
                column: "EvaluationQuestionId",
                principalTable: "EvaluationQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
