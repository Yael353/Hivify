using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansjon.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTenantCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tenant");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tenant",
                newName: "TenantId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Tenant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tenant");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Tenant",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tenant",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Tenant",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
