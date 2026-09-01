using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hivify.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "StaffMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "StaffMembers");
        }
    }
}
