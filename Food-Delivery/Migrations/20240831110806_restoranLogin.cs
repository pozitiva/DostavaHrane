using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DostavaHrane.Migrations
{
    /// <inheritdoc />
    public partial class restoranLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Musterije");

            migrationBuilder.DropColumn(
                name: "SifraHash",
                table: "Musterije");

            migrationBuilder.DropColumn(
                name: "SifraSalt",
                table: "Musterije");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "SifraHash",
                table: "Korisnici",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "SifraSalt",
                table: "Korisnici",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "SifraHash",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "SifraSalt",
                table: "Korisnici");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Musterije",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
