using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jukebox.Migrations
{
    /// <inheritdoc />
    public partial class updateSavedSongSTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saved_Songs_PlayLists_PlaylistId",
                table: "Saved_Songs");

            migrationBuilder.AddForeignKey(
                name: "FK_Saved_Songs_PlayLists_PlaylistId",
                table: "Saved_Songs",
                column: "PlaylistId",
                principalTable: "PlayLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saved_Songs_PlayLists_PlaylistId",
                table: "Saved_Songs");

            migrationBuilder.AddForeignKey(
                name: "FK_Saved_Songs_PlayLists_PlaylistId",
                table: "Saved_Songs",
                column: "PlaylistId",
                principalTable: "PlayLists",
                principalColumn: "Id");
        }
    }
}
