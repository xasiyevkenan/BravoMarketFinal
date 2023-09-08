using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddCardImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BgColor",
                table: "CardTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSlider",
                table: "CardTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgColor",
                table: "CardTypes");

            migrationBuilder.DropColumn(
                name: "IsSlider",
                table: "CardTypes");
        }
    }
}
