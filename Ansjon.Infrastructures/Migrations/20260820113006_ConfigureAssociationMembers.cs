using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureAssociationMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssociationId1",
                table: "StaffMembers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_AssociationId1",
                table: "StaffMembers",
                column: "AssociationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffMembers_Associations_AssociationId1",
                table: "StaffMembers",
                column: "AssociationId1",
                principalTable: "Associations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffMembers_Associations_AssociationId1",
                table: "StaffMembers");

            migrationBuilder.DropIndex(
                name: "IX_StaffMembers_AssociationId1",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "AssociationId1",
                table: "StaffMembers");
        }
    }
}
