using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddAboutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstBannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastBannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporativeValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporativeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporativeValue_About_AboutId",
                        column: x => x.AboutId,
                        principalTable: "About",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Standart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standart_About_AboutId",
                        column: x => x.AboutId,
                        principalTable: "About",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Values_About_AboutId",
                        column: x => x.AboutId,
                        principalTable: "About",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visions_About_AboutId",
                        column: x => x.AboutId,
                        principalTable: "About",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandartThrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandartHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstStandart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondStandart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdStandart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthStandart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandartId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartThrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandartThrees_Standart_StandartId",
                        column: x => x.StandartId,
                        principalTable: "Standart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorporativeValue_AboutId",
                table: "CorporativeValue",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Standart_AboutId",
                table: "Standart",
                column: "AboutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandartThrees_StandartId",
                table: "StandartThrees",
                column: "StandartId");

            migrationBuilder.CreateIndex(
                name: "IX_Values_AboutId",
                table: "Values",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Visions_AboutId",
                table: "Visions",
                column: "AboutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporativeValue");

            migrationBuilder.DropTable(
                name: "StandartThrees");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Visions");

            migrationBuilder.DropTable(
                name: "Standart");

            migrationBuilder.DropTable(
                name: "About");
        }
    }
}
