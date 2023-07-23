using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace jukebox.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlayLists",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 40, "Lofi", "bd1d889c-0482-4a8c-ac22-dfa0769f95a8" },
                    { 41, "Rap", "bd1d889c-0482-4a8c-ac22-dfa0769f95a8" },
                    { 42, "Lofi", "aa164a31-0ce0-47f3-945d-577a9625affb" },
                    { 43, "Rap", "aa164a31-0ce0-47f3-945d-577a9625affb" },
                    { 45, "Lofi", "fa970c7f-7425-4bba-96bc-5502113f858b" },
                    { 46, "Rap", "fa970c7f-7425-4bba-96bc-5502113f858b" }
                });

            migrationBuilder.InsertData(
                table: "Saved_Songs",
                columns: new[] { "Id", "PlaylistId", "SongsId" },
                values: new object[,]
                {
                    { 100, 21, 2 },
                    { 101, 21, 2 },
                    { 102, 31, 3 },
                    { 110, 31, 4 },
                    { 114, 31, 5 },
                    { 125, 31, 6 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Artist", "GenresId", "Length", "Name" },
                values: new object[,]
                {
                    { 10, "Eagles ", 4, new TimeSpan(0, 0, 6, 0, 0), "Hotel California" },
                    { 11, "Otis redding", 4, new TimeSpan(0, 0, 2, 10, 0), "Respect" },
                    { 12, "Freddie perren", 4, new TimeSpan(0, 0, 3, 13, 0), "I will survive" },
                    { 13, "Johnny Cash", 5, new TimeSpan(0, 0, 4, 0, 0), "I Walk the Line" },
                    { 14, "Dolly Parton", 5, new TimeSpan(0, 0, 3, 35, 0), "Jolene" },
                    { 15, "Garth Brooks", 5, new TimeSpan(0, 0, 5, 0, 0), "Friends in Low Places" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Saved_Songs",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Saved_Songs",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Saved_Songs",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Saved_Songs",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Saved_Songs",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Saved_Songs",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
