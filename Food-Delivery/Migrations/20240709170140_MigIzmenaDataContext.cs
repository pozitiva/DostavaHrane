using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DostavaHrane.Migrations
{
    /// <inheritdoc />
    public partial class MigIzmenaDataContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkeNarudzbina_Narudzbine_NarudzbinaId",
                table: "StavkeNarudzbina");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Narudzbine",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeNarudzbina_Narudzbine_NarudzbinaId",
                table: "StavkeNarudzbina",
                column: "NarudzbinaId",
                principalTable: "Narudzbine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkeNarudzbina_Narudzbine_NarudzbinaId",
                table: "StavkeNarudzbina");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Narudzbine",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeNarudzbina_Narudzbine_NarudzbinaId",
                table: "StavkeNarudzbina",
                column: "NarudzbinaId",
                principalTable: "Narudzbine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
