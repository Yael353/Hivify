using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureAssociationMMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StaffMembers_AssociationId",
                table: "StaffMembers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "StaffMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "StaffMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_AssociationId_UserId",
                table: "StaffMembers",
                columns: new[] { "AssociationId", "UserId" },
                unique: true,
                filter: "[DeletedAt] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StaffMembers_AssociationId_UserId",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StaffMembers");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_AssociationId",
                table: "StaffMembers",
                column: "AssociationId");
        }
    }
}
