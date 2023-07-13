using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jukebox.Migrations
{
    /// <inheritdoc />
    public partial class SavedSongsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saved_Songs_AspNetUsers_UserId",
                table: "Saved_Songs");

            migrationBuilder.DropIndex(
                name: "IX_Saved_Songs_UserId",
                table: "Saved_Songs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Saved_Songs");

            migrationBuilder.AddColumn<int>(
                name: "SongsId",
                table: "Saved_Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saved_Songs_SongsId",
                table: "Saved_Songs",
                column: "SongsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saved_Songs_Songs_SongsId",
                table: "Saved_Songs",
                column: "SongsId",
                principalTable: "Songs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saved_Songs_Songs_SongsId",
                table: "Saved_Songs");

            migrationBuilder.DropIndex(
                name: "IX_Saved_Songs_SongsId",
                table: "Saved_Songs");

            migrationBuilder.DropColumn(
                name: "SongsId",
                table: "Saved_Songs");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Saved_Songs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Saved_Songs_UserId",
                table: "Saved_Songs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saved_Songs_AspNetUsers_UserId",
                table: "Saved_Songs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
