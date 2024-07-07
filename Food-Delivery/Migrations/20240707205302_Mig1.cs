using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SifraHash",
                table: "Musterije",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "SifraSalt",
                table: "Musterije",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "VerifikacioniToken",
                table: "Musterije",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Verifikovano",
                table: "Musterije",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SifraHash",
                table: "Musterije");

            migrationBuilder.DropColumn(
                name: "SifraSalt",
                table: "Musterije");

            migrationBuilder.DropColumn(
                name: "VerifikacioniToken",
                table: "Musterije");

            migrationBuilder.DropColumn(
                name: "Verifikovano",
                table: "Musterije");
        }
    }
}
