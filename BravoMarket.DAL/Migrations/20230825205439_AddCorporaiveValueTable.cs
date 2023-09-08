using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddCorporaiveValueTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorporativeValue_About_AboutId",
                table: "CorporativeValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CorporativeValue",
                table: "CorporativeValue");

            migrationBuilder.RenameTable(
                name: "CorporativeValue",
                newName: "CorporativeValues");

            migrationBuilder.RenameIndex(
                name: "IX_CorporativeValue_AboutId",
                table: "CorporativeValues",
                newName: "IX_CorporativeValues_AboutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CorporativeValues",
                table: "CorporativeValues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CorporativeValues_About_AboutId",
                table: "CorporativeValues",
                column: "AboutId",
                principalTable: "About",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorporativeValues_About_AboutId",
                table: "CorporativeValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CorporativeValues",
                table: "CorporativeValues");

            migrationBuilder.RenameTable(
                name: "CorporativeValues",
                newName: "CorporativeValue");

            migrationBuilder.RenameIndex(
                name: "IX_CorporativeValues_AboutId",
                table: "CorporativeValue",
                newName: "IX_CorporativeValue_AboutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CorporativeValue",
                table: "CorporativeValue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CorporativeValue_About_AboutId",
                table: "CorporativeValue",
                column: "AboutId",
                principalTable: "About",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
