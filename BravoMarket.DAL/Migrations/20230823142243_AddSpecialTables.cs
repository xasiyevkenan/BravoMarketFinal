using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddSpecialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Special",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonInner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Special", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonInner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonBg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialOffers_Special_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Special",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MarketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdfUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialOfferId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketTypes_SpecialOffers_SpecialOfferId",
                        column: x => x.SpecialOfferId,
                        principalTable: "SpecialOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketTypes_SpecialOfferId",
                table: "MarketTypes",
                column: "SpecialOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffers_SpecialId",
                table: "SpecialOffers",
                column: "SpecialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketTypes");

            migrationBuilder.DropTable(
                name: "SpecialOffers");

            migrationBuilder.DropTable(
                name: "Special");
        }
    }
}
