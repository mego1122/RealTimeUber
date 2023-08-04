using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeUber.Migrations
{
    public partial class initial22rueews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_IdentityUser_DriverId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_IdentityUser_PassengerId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DriverId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "Trips",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_PassengerId",
                table: "Trips",
                newName: "IX_Trips_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_IdentityUser_IdentityUserId",
                table: "Trips",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_IdentityUser_IdentityUserId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Trips",
                newName: "PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_IdentityUserId",
                table: "Trips",
                newName: "IX_Trips_PassengerId");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DriverId",
                table: "Trips",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_IdentityUser_DriverId",
                table: "Trips",
                column: "DriverId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_IdentityUser_PassengerId",
                table: "Trips",
                column: "PassengerId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
