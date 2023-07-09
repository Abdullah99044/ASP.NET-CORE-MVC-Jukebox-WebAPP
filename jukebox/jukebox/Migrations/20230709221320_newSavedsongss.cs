using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jukebox.Migrations
{
    /// <inheritdoc />
    public partial class newSavedsongss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saved_Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saved_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saved_Songs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Saved_Songs_PlayLists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Saved_Songs_PlaylistId",
                table: "Saved_Songs",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Saved_Songs_UserId",
                table: "Saved_Songs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saved_Songs");
        }
    }
}
