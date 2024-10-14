using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserMovieWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("d7018b5a-70f8-4a2c-b7de-bc5dd82f2e11"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("f87f6d37-56c9-4c2a-b57c-728a21ae6970"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b8eff247-a9ec-4124-95f6-b96b31c3d700"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d5ce08dc-88f1-4306-a6ca-779448661064"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ApplicationUserMovie",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMovie", x => new { x.UserGuid, x.MovieGuid });
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovie_AspNetUsers_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovie_Movies_MovieGuid",
                        column: x => x.MovieGuid,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("230739e2-0206-439f-9934-1f4f6548c2e7"), "Svishtov", "Latona" },
                    { new Guid("6b6d51a6-025c-4a96-9da0-5af59bd8df3f"), "Ring Mall Sofia", "CineGrand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("066998fd-4194-4f94-b2e3-74b5039314de"), "Some description", "Peter Jackson", 278, "Fantasy", new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Of The Rings" },
                    { new Guid("d6e5e824-369d-4b41-885b-668d9ec9b57a"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMovie_MovieGuid",
                table: "ApplicationUserMovie",
                column: "MovieGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserMovie");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("230739e2-0206-439f-9934-1f4f6548c2e7"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6b6d51a6-025c-4a96-9da0-5af59bd8df3f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("066998fd-4194-4f94-b2e3-74b5039314de"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d6e5e824-369d-4b41-885b-668d9ec9b57a"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("d7018b5a-70f8-4a2c-b7de-bc5dd82f2e11"), "Ring Mall Sofia", "CineGrand" },
                    { new Guid("f87f6d37-56c9-4c2a-b57c-728a21ae6970"), "Svishtov", "Latona" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("b8eff247-a9ec-4124-95f6-b96b31c3d700"), "Some description", "Peter Jackson", 278, "Fantasy", new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Of The Rings" },
                    { new Guid("d5ce08dc-88f1-4306-a6ca-779448661064"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" }
                });
        }
    }
}
