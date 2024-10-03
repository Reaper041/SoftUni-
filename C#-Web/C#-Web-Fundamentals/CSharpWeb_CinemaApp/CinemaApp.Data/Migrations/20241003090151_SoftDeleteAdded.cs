using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("2c697673-eccc-4f76-b628-e56411c3b13a"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("8b540493-d805-4eac-b5f9-47e3348dcbe5"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("03ad5d10-4386-4258-b8ab-0906e763580a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8018ab04-5af1-44a0-ba60-66ff6f23dab3"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CinemasMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("11e4334e-12a4-4aa2-8224-ed3d06d71f8d"), "Svishtov", "Latona" },
                    { new Guid("1a67d4ae-7306-481d-a2d4-50dde4bbcd85"), "Ring Mall Sofia", "CineGrand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("548dd582-22c2-45a1-81e2-cfb394ae8549"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" },
                    { new Guid("dd541030-e76f-4969-bcfb-a6119b9c4b1f"), "Some description", "Peter Jackson", 278, "Fantasy", new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Of The Rings" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("11e4334e-12a4-4aa2-8224-ed3d06d71f8d"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("1a67d4ae-7306-481d-a2d4-50dde4bbcd85"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("548dd582-22c2-45a1-81e2-cfb394ae8549"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("dd541030-e76f-4969-bcfb-a6119b9c4b1f"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CinemasMovies");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("2c697673-eccc-4f76-b628-e56411c3b13a"), "Svishtov", "Latona" },
                    { new Guid("8b540493-d805-4eac-b5f9-47e3348dcbe5"), "Ring Mall Sofia", "CineGrand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("03ad5d10-4386-4258-b8ab-0906e763580a"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" },
                    { new Guid("8018ab04-5af1-44a0-ba60-66ff6f23dab3"), "Some description", "Peter Jackson", 278, "Fantasy", new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Of The Rings" }
                });
        }
    }
}
