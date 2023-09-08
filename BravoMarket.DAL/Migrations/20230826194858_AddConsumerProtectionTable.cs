using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddConsumerProtectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ConsumerProtection_ContactId",
                table: "ConsumerProtection");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerProtection_ContactId",
                table: "ConsumerProtection",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ConsumerProtection_ContactId",
                table: "ConsumerProtection");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerProtection_ContactId",
                table: "ConsumerProtection",
                column: "ContactId",
                unique: true);
        }
    }
}
