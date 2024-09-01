using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DostavaHrane.Migrations
{
    /// <inheritdoc />
    public partial class opisRestorana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RadnoVreme",
                table: "Restorani",
                newName: "Opis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "Restorani",
                newName: "RadnoVreme");
        }
    }
}
