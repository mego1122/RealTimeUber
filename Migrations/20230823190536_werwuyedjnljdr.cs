using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeUber.Migrations
{
    /// <inheritdoc />
    public partial class werwuyedjnljdr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartLocations_Users_ApplicationUserId",
                table: "StartLocations");

            migrationBuilder.AddForeignKey(
                name: "FK_StartLocations_Users_ApplicationUserId",
                table: "StartLocations",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartLocations_Users_ApplicationUserId",
                table: "StartLocations");

            migrationBuilder.AddForeignKey(
                name: "FK_StartLocations_Users_ApplicationUserId",
                table: "StartLocations",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
