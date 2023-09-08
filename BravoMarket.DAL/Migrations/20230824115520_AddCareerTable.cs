using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddCareerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvantageThree_Advantages_AdvantageId",
                table: "AdvantageThree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvantageThree",
                table: "AdvantageThree");

            migrationBuilder.RenameTable(
                name: "AdvantageThree",
                newName: "AdvantagesThree");

            migrationBuilder.RenameIndex(
                name: "IX_AdvantageThree_AdvantageId",
                table: "AdvantagesThree",
                newName: "IX_AdvantagesThree_AdvantageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvantagesThree",
                table: "AdvantagesThree",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BGImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonInner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkController = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Career", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdvantagesThree_Advantages_AdvantageId",
                table: "AdvantagesThree",
                column: "AdvantageId",
                principalTable: "Advantages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvantagesThree_Advantages_AdvantageId",
                table: "AdvantagesThree");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvantagesThree",
                table: "AdvantagesThree");

            migrationBuilder.RenameTable(
                name: "AdvantagesThree",
                newName: "AdvantageThree");

            migrationBuilder.RenameIndex(
                name: "IX_AdvantagesThree_AdvantageId",
                table: "AdvantageThree",
                newName: "IX_AdvantageThree_AdvantageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvantageThree",
                table: "AdvantageThree",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvantageThree_Advantages_AdvantageId",
                table: "AdvantageThree",
                column: "AdvantageId",
                principalTable: "Advantages",
                principalColumn: "Id");
        }
    }
}
