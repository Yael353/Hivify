using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tenant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tenant");
        }
    }
}
