using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class addedIsDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Feeds",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Feeds");
        }
    }
}
