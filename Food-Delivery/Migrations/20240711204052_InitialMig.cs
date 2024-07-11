using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DostavaHrane.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dostavljaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojDostava = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostavljaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musterije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SifraHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SifraSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerifikacioniToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musterije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musterije_Korisnici_Id",
                        column: x => x.Id,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restorani",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RadnoVreme = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restorani", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restorani_Korisnici_Id",
                        column: x => x.Id,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusterijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adrese_Musterije_MusterijaId",
                        column: x => x.MusterijaId,
                        principalTable: "Musterije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipJela = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RestoranId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jela_Restorani_RestoranId",
                        column: x => x.RestoranId,
                        principalTable: "Restorani",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumNarudzbine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UkupnaCena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DostavljacId = table.Column<int>(type: "int", nullable: false),
                    RestoranId = table.Column<int>(type: "int", nullable: false),
                    AdresaId = table.Column<int>(type: "int", nullable: false),
                    MusterijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Adrese_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adrese",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Dostavljaci_DostavljacId",
                        column: x => x.DostavljacId,
                        principalTable: "Dostavljaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Musterije_MusterijaId",
                        column: x => x.MusterijaId,
                        principalTable: "Musterije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbine_Restorani_RestoranId",
                        column: x => x.RestoranId,
                        principalTable: "Restorani",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StavkeNarudzbina",
                columns: table => new
                {
                    JeloId = table.Column<int>(type: "int", nullable: false),
                    NarudzbinaId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeNarudzbina", x => new { x.JeloId, x.NarudzbinaId });
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbina_Jela_JeloId",
                        column: x => x.JeloId,
                        principalTable: "Jela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbina_Narudzbine_NarudzbinaId",
                        column: x => x.NarudzbinaId,
                        principalTable: "Narudzbine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_MusterijaId",
                table: "Adrese",
                column: "MusterijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_RestoranId",
                table: "Jela",
                column: "RestoranId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_AdresaId",
                table: "Narudzbine",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_DostavljacId",
                table: "Narudzbine",
                column: "DostavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_MusterijaId",
                table: "Narudzbine",
                column: "MusterijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbine_RestoranId",
                table: "Narudzbine",
                column: "RestoranId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbina_NarudzbinaId",
                table: "StavkeNarudzbina",
                column: "NarudzbinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StavkeNarudzbina");

            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "Narudzbine");

            migrationBuilder.DropTable(
                name: "Adrese");

            migrationBuilder.DropTable(
                name: "Dostavljaci");

            migrationBuilder.DropTable(
                name: "Restorani");

            migrationBuilder.DropTable(
                name: "Musterije");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
