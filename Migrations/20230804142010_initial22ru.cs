using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeUber.Migrations
{
    public partial class initial22ru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_DriverId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_PassengerId",
                table: "Ratings");

            migrationBuilder.AlterColumn<string>(
                name: "PassengerId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_DriverId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_IdentityUser_PassengerId",
                table: "Ratings");

            migrationBuilder.AlterColumn<string>(
                name: "PassengerId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_IdentityUser_DriverId",
                table: "Ratings",
                column: "DriverId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_IdentityUser_PassengerId",
                table: "Ratings",
                column: "PassengerId",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }
    }
}
