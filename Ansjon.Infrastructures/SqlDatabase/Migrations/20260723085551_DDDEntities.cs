using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class DDDEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Feeds",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "This is the first seeded feed.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Welcome to Ansjon" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Learn how to use the platform.", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Getting Started" }
                });
        }
    }
}
