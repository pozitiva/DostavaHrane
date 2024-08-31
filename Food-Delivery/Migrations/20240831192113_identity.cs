using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DostavaHrane.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SifraSalt",
                table: "Korisnici");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "StavkeNarudzbina",
                newName: "StavkeNarudzbina",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Restorani",
                newName: "Restorani",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Narudzbine",
                newName: "Narudzbine",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Musterije",
                newName: "Musterije",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Korisnici",
                newName: "Korisnici",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Jela",
                newName: "Jela",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Dostavljaci",
                newName: "Dostavljaci",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Adrese",
                newName: "Adrese",
                newSchema: "identity");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "identity",
                table: "Korisnici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "identity",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "identity",
                table: "Korisnici",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "identity",
                table: "Korisnici",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "identity",
                table: "Korisnici",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "identity",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "identity",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "identity",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "identity",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "identity",
                table: "Korisnici",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "identity",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "identity",
                table: "Korisnici",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "identity",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "identity",
                table: "Korisnici");

            migrationBuilder.RenameTable(
                name: "StavkeNarudzbina",
                schema: "identity",
                newName: "StavkeNarudzbina");

            migrationBuilder.RenameTable(
                name: "Restorani",
                schema: "identity",
                newName: "Restorani");

            migrationBuilder.RenameTable(
                name: "Narudzbine",
                schema: "identity",
                newName: "Narudzbine");

            migrationBuilder.RenameTable(
                name: "Musterije",
                schema: "identity",
                newName: "Musterije");

            migrationBuilder.RenameTable(
                name: "Korisnici",
                schema: "identity",
                newName: "Korisnici");

            migrationBuilder.RenameTable(
                name: "Jela",
                schema: "identity",
                newName: "Jela");

            migrationBuilder.RenameTable(
                name: "Dostavljaci",
                schema: "identity",
                newName: "Dostavljaci");

            migrationBuilder.RenameTable(
                name: "Adrese",
                schema: "identity",
                newName: "Adrese");

            migrationBuilder.AddColumn<byte[]>(
                name: "SifraSalt",
                table: "Korisnici",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
