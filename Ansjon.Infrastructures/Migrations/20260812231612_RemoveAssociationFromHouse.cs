using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAssociationFromHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Associations_AssociationId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_AssociationId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "AssociationId",
                table: "Houses");

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "Tenant",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_HouseId",
                table: "Tenant",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Houses_HouseId",
                table: "Tenant",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Houses_HouseId",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_HouseId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Tenant");

            migrationBuilder.AddColumn<Guid>(
                name: "AssociationId",
                table: "Houses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AssociationId",
                table: "Houses",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Associations_AssociationId",
                table: "Houses",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
