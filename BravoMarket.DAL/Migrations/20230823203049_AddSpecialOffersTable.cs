using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddSpecialOffersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketTypes_SpecialOffers_SpecialOfferId",
                table: "MarketTypes");

            migrationBuilder.RenameColumn(
                name: "SpecialOfferId",
                table: "MarketTypes",
                newName: "SpecialId");

            migrationBuilder.RenameIndex(
                name: "IX_MarketTypes_SpecialOfferId",
                table: "MarketTypes",
                newName: "IX_MarketTypes_SpecialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketTypes_Special_SpecialId",
                table: "MarketTypes",
                column: "SpecialId",
                principalTable: "Special",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketTypes_Special_SpecialId",
                table: "MarketTypes");

            migrationBuilder.RenameColumn(
                name: "SpecialId",
                table: "MarketTypes",
                newName: "SpecialOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_MarketTypes_SpecialId",
                table: "MarketTypes",
                newName: "IX_MarketTypes_SpecialOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketTypes_SpecialOffers_SpecialOfferId",
                table: "MarketTypes",
                column: "SpecialOfferId",
                principalTable: "SpecialOffers",
                principalColumn: "Id");
        }
    }
}
