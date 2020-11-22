using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EQUIZY.Data.Migrations
{
    public partial class Evaluationstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_CategoriesEvaluation_CategoryEvaluationId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_AspNetUsers_CreatedById1",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_TopicsEvaluation_TopicEvaluationId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_TypesEvaluation_TypeEvaluationId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationQuestion_Evaluation_EvaluationId",
                table: "EvaluationQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluation",
                table: "Evaluation");

            migrationBuilder.DropIndex(
                name: "IX_Evaluation_CreatedById1",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Evaluation");

            migrationBuilder.RenameTable(
                name: "Evaluation",
                newName: "Evaluations");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_TypeEvaluationId",
                table: "Evaluations",
                newName: "IX_Evaluations_TypeEvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_TopicEvaluationId",
                table: "Evaluations",
                newName: "IX_Evaluations_TopicEvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_CategoryEvaluationId",
                table: "Evaluations",
                newName: "IX_Evaluations_CategoryEvaluationId");

            migrationBuilder.AlterColumn<string>(
                name: "Rules",
                table: "Evaluations",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Evaluations",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120) CHARACTER SET utf8mb4",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Evaluations",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "Evaluations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Evaluations",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProfessorEvaluationList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorEvaluationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorEvaluationList_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorEvaluationList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CreatedById",
                table: "Evaluations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorEvaluationList_EvaluationId",
                table: "ProfessorEvaluationList",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorEvaluationList_UserId",
                table: "ProfessorEvaluationList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationQuestion_Evaluations_EvaluationId",
                table: "EvaluationQuestion",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_CategoriesEvaluation_CategoryEvaluationId",
                table: "Evaluations",
                column: "CategoryEvaluationId",
                principalTable: "CategoriesEvaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_AspNetUsers_CreatedById",
                table: "Evaluations",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_TopicsEvaluation_TopicEvaluationId",
                table: "Evaluations",
                column: "TopicEvaluationId",
                principalTable: "TopicsEvaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_TypesEvaluation_TypeEvaluationId",
                table: "Evaluations",
                column: "TypeEvaluationId",
                principalTable: "TypesEvaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationQuestion_Evaluations_EvaluationId",
                table: "EvaluationQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_CategoriesEvaluation_CategoryEvaluationId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_AspNetUsers_CreatedById",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_TopicsEvaluation_TopicEvaluationId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_TypesEvaluation_TypeEvaluationId",
                table: "Evaluations");

            migrationBuilder.DropTable(
                name: "ProfessorEvaluationList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_CreatedById",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Evaluations");

            migrationBuilder.RenameTable(
                name: "Evaluations",
                newName: "Evaluation");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_TypeEvaluationId",
                table: "Evaluation",
                newName: "IX_Evaluation_TypeEvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_TopicEvaluationId",
                table: "Evaluation",
                newName: "IX_Evaluation_TopicEvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_CategoryEvaluationId",
                table: "Evaluation",
                newName: "IX_Evaluation_CategoryEvaluationId");

            migrationBuilder.AlterColumn<string>(
                name: "Rules",
                table: "Evaluation",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Evaluation",
                type: "varchar(120) CHARACTER SET utf8mb4",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Evaluation",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Evaluation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById1",
                table: "Evaluation",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluation",
                table: "Evaluation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CreatedById1",
                table: "Evaluation",
                column: "CreatedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_CategoriesEvaluation_CategoryEvaluationId",
                table: "Evaluation",
                column: "CategoryEvaluationId",
                principalTable: "CategoriesEvaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_AspNetUsers_CreatedById1",
                table: "Evaluation",
                column: "CreatedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_TopicsEvaluation_TopicEvaluationId",
                table: "Evaluation",
                column: "TopicEvaluationId",
                principalTable: "TopicsEvaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_TypesEvaluation_TypeEvaluationId",
                table: "Evaluation",
                column: "TypeEvaluationId",
                principalTable: "TypesEvaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationQuestion_Evaluation_EvaluationId",
                table: "EvaluationQuestion",
                column: "EvaluationId",
                principalTable: "Evaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
