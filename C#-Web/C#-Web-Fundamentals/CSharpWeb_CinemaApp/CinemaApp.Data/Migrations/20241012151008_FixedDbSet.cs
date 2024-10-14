using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_UserGuid",
                table: "ApplicationUserMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_Movies_MovieGuid",
                table: "ApplicationUserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("5ca867ef-4e4e-4135-b81c-071fa70231e6"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("9aaa12a2-1192-43e9-9e2c-34a354e536a9"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8ebc5b93-ab5e-4364-b9d1-c89f3b8105e7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bd077ecb-8ea3-404f-a241-09bf7a293097"));

            migrationBuilder.RenameTable(
                name: "ApplicationUserMovie",
                newName: "UsersMovies");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserMovie_MovieGuid",
                table: "UsersMovies",
                newName: "IX_UsersMovies_MovieGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies",
                columns: new[] { "UserGuid", "MovieGuid" });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("468ea2f6-8263-4257-b5f3-f1029293b66d"), "Svishtov", "Latona" },
                    { new Guid("5efed735-28e6-42aa-89f9-7ab190d0aaa0"), "Ring Mall Sofia", "CineGrand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("03db33bf-2b40-4626-a8e7-83edb0963c40"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" },
                    { new Guid("c00abead-0f99-4862-9951-7916943a15cd"), "Some description", "Peter Jackson", 278, "Fantasy", new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Of The Rings" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_AspNetUsers_UserGuid",
                table: "UsersMovies",
                column: "UserGuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Movies_MovieGuid",
                table: "UsersMovies",
                column: "MovieGuid",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_AspNetUsers_UserGuid",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Movies_MovieGuid",
                table: "UsersMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("468ea2f6-8263-4257-b5f3-f1029293b66d"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("5efed735-28e6-42aa-89f9-7ab190d0aaa0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("03db33bf-2b40-4626-a8e7-83edb0963c40"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c00abead-0f99-4862-9951-7916943a15cd"));

            migrationBuilder.RenameTable(
                name: "UsersMovies",
                newName: "ApplicationUserMovie");

            migrationBuilder.RenameIndex(
                name: "IX_UsersMovies_MovieGuid",
                table: "ApplicationUserMovie",
                newName: "IX_ApplicationUserMovie_MovieGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie",
                columns: new[] { "UserGuid", "MovieGuid" });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5ca867ef-4e4e-4135-b81c-071fa70231e6"), "Ring Mall Sofia", "CineGrand" },
                    { new Guid("9aaa12a2-1192-43e9-9e2c-34a354e536a9"), "Svishtov", "Latona" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("8ebc5b93-ab5e-4364-b9d1-c89f3b8105e7"), "Some description", "Peter Jackson", 278, "Fantasy", new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Of The Rings" },
                    { new Guid("bd077ecb-8ea3-404f-a241-09bf7a293097"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_UserGuid",
                table: "ApplicationUserMovie",
                column: "UserGuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_Movies_MovieGuid",
                table: "ApplicationUserMovie",
                column: "MovieGuid",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
