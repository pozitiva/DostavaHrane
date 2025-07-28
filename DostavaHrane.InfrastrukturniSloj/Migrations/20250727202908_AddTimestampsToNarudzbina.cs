using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DostavaHrane.InfrastrukturniSloj.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampsToNarudzbina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VremeDostave",
                table: "Narudzbine",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VremeOtkazivanja",
                table: "Narudzbine",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VremeDostave",
                table: "Narudzbine");

            migrationBuilder.DropColumn(
                name: "VremeOtkazivanja",
                table: "Narudzbine");
        }
    }
}
