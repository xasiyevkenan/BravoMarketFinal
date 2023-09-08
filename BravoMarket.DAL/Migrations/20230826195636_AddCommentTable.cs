using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BravoMarket.DAL.Migrations
{
    public partial class AddCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "CommentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentTypes_CommentId",
                table: "CommentTypes",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentTypes_Comment_CommentId",
                table: "CommentTypes",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentTypes_Comment_CommentId",
                table: "CommentTypes");

            migrationBuilder.DropIndex(
                name: "IX_CommentTypes_CommentId",
                table: "CommentTypes");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "CommentTypes");
        }
    }
}
