using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeUber.Migrations
{
    public partial class initial22r : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_IdentityUserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_IdentityUserId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Ratings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_IdentityUserId",
                table: "Ratings",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_IdentityUser_IdentityUserId",
                table: "Ratings",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
