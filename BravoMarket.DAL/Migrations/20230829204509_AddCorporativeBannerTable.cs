using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddCorporativeBannerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BGColor",
                table: "CorporativeBanner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BottomColor",
                table: "CorporativeBanner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BGColor",
                table: "CorporativeBanner");

            migrationBuilder.DropColumn(
                name: "BottomColor",
                table: "CorporativeBanner");
        }
    }
}
