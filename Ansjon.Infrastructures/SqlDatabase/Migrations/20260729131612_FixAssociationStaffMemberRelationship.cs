using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixAssociationStaffMemberRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssociationId",
                table: "StaffMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_AssociationId",
                table: "StaffMembers",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffMembers_Associations_AssociationId",
                table: "StaffMembers",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffMembers_Associations_AssociationId",
                table: "StaffMembers");

            migrationBuilder.DropIndex(
                name: "IX_StaffMembers_AssociationId",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "AssociationId",
                table: "StaffMembers");
        }
    }
}
