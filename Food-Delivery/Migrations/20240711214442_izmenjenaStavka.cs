using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DostavaHrane.Migrations
{
    /// <inheritdoc />
    public partial class izmenjenaStavka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StavkaNarudzbineId",
                table: "StavkeNarudzbina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StavkaNarudzbineId",
                table: "StavkeNarudzbina",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
