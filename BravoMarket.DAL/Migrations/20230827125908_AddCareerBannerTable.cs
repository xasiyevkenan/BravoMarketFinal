using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddCareerBannerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CareerId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CareerId",
                table: "Preference",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CareerId",
                table: "Employer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CareerBanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerBanner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareerBanner_Career_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Career",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CareerId",
                table: "Vacancies",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_CareerId",
                table: "Preference",
                column: "CareerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employer_CareerId",
                table: "Employer",
                column: "CareerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CareerBanner_CareerId",
                table: "CareerBanner",
                column: "CareerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_Career_CareerId",
                table: "Employer",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Preference_Career_CareerId",
                table: "Preference",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Career_CareerId",
                table: "Vacancies",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employer_Career_CareerId",
                table: "Employer");

            migrationBuilder.DropForeignKey(
                name: "FK_Preference_Career_CareerId",
                table: "Preference");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Career_CareerId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "CareerBanner");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_CareerId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Preference_CareerId",
                table: "Preference");

            migrationBuilder.DropIndex(
                name: "IX_Employer_CareerId",
                table: "Employer");

            migrationBuilder.DropColumn(
                name: "CareerId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "CareerId",
                table: "Preference");

            migrationBuilder.DropColumn(
                name: "CareerId",
                table: "Employer");
        }
    }
}
