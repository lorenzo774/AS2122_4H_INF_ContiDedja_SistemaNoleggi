using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess_Library.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veicoli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Targa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modello = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponibile = table.Column<bool>(type: "bit", nullable: false),
                    CostoVeicolo = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: false),
                    TariffaGiornaliera = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veicoli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noleggi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurataNoleggio = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    VeicoloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noleggi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noleggi_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Noleggi_Veicoli_VeicoloId",
                        column: x => x.VeicoloId,
                        principalTable: "Veicoli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noleggi_ClienteId",
                table: "Noleggi",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Noleggi_VeicoloId",
                table: "Noleggi",
                column: "VeicoloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noleggi");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Veicoli");
        }
    }
}
