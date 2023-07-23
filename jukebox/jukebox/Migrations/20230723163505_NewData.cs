using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace jukebox.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Artist", "GenresId", "Length", "Name" },
                values: new object[,]
                {
                    { 7, "Michael Jackson", 3, new TimeSpan(0, 0, 5, 0, 0), "Thriller" },
                    { 8, " A-ha", 3, new TimeSpan(0, 0, 4, 30, 0), "Take On Me" },
                    { 9, "Michael Jackson", 3, new TimeSpan(0, 0, 4, 48, 0), "Beat It" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
