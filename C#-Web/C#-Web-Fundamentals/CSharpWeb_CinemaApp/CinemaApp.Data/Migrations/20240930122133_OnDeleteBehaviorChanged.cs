using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteBehaviorChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemasMovies_Cinemas_CinemaId",
                table: "CinemasMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemasMovies_Movies_MovieId",
                table: "CinemasMovies");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("9164c53c-fa77-4808-be37-53d4d57a6f92"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("cb733582-3ad8-4bae-9c0a-08c3bce13cee"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3f366a8e-6ef0-4360-af70-36fc97c9018c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b3620c1b-f63b-48bf-83f4-6af9e47a2af4"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_CinemasMovies_Cinemas_CinemaId",
                table: "CinemasMovies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemasMovies_Movies_MovieId",
                table: "CinemasMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemasMovies_Cinemas_CinemaId",
                table: "CinemasMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemasMovies_Movies_MovieId",
                table: "CinemasMovies");

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

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("9164c53c-fa77-4808-be37-53d4d57a6f92"), "Svishtov", "Latona" },
                    { new Guid("cb733582-3ad8-4bae-9c0a-08c3bce13cee"), "Ring Mall Sofia", "CineGrand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("3f366a8e-6ef0-4360-af70-36fc97c9018c"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" },
                    { new Guid("b3620c1b-f63b-48bf-83f4-6af9e47a2af4"), "Some description", "Peter Jackson", 278, "Fantasy", new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Of The Rings" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CinemasMovies_Cinemas_CinemaId",
                table: "CinemasMovies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemasMovies_Movies_MovieId",
                table: "CinemasMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
