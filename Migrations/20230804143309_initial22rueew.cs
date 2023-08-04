using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeUber.Migrations
{
    public partial class initial22rueew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_DriverId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_PassengerId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_DriverId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "Ratings",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_PassengerId",
                table: "Ratings",
                newName: "IX_Ratings_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_IdentityUser_IdentityUserId",
                table: "Ratings",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_IdentityUserId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Ratings",
                newName: "PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_IdentityUserId",
                table: "Ratings",
                newName: "IX_Ratings_PassengerId");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DriverId",
                table: "Ratings",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_IdentityUser_DriverId",
                table: "Ratings",
                column: "DriverId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_IdentityUser_PassengerId",
                table: "Ratings",
                column: "PassengerId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
