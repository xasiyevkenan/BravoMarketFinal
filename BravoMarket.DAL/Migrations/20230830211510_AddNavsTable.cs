using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddNavsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Header_Logos_LogoId",
                table: "Header");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropIndex(
                name: "IX_Header_LogoId",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Header");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Header",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Header");

            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "Header",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Logos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Header_LogoId",
                table: "Header",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Header_Logos_LogoId",
                table: "Header",
                column: "LogoId",
                principalTable: "Logos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
