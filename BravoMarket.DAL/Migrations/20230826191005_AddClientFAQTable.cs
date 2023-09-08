using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddClientFAQTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientFAQ_ContactId",
                table: "ClientFAQ");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFAQ_ContactId",
                table: "ClientFAQ",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientFAQ_ContactId",
                table: "ClientFAQ");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFAQ_ContactId",
                table: "ClientFAQ",
                column: "ContactId",
                unique: true);
        }
    }
}
