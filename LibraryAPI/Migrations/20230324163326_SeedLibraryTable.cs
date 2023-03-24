using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedLibraryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "AuthorName", "CreatedDate", "Description", "Name", "Price", "UpdatedDate", "yearOfPublication" },
                values: new object[,]
                {
                    { 1, "Czesław Bogucin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Książka o czarach", "Czerwień Rubinu", 62.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2012 },
                    { 2, "C.S Lewis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Przygoda", "Opowieści z Narnii", 50.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1950 },
                    { 3, "J.K Rowling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Książka o czarach", "Harry Potter", 12.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1987 },
                    { 4, "Stanisław Lem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Literatura piękna", "Solaris", 99.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1876 },
                    { 5, "George  R.R. Martin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walka o władze", "Gra o Tron", 2.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1992 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
