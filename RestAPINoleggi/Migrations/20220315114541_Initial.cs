using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPINoleggi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Clienti",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CF = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Cognome = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Clienti", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Veicolo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Targa = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Modello = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CostoVeicolo = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: false),
            //        TariffaGiornaliera = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: false),
            //        Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NumeroPosti = table.Column<int>(type: "int", nullable: true),
            //        Capacita = table.Column<double>(type: "float", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Veicolo", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Noleggi",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DurataNoleggio = table.Column<int>(type: "int", nullable: false),
            //        ClienteId = table.Column<int>(type: "int", nullable: true),
            //        VeicoloId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Noleggi", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Noleggi_Clienti_ClienteId",
            //            column: x => x.ClienteId,
            //            principalTable: "Clienti",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Noleggi_Veicolo_VeicoloId",
            //            column: x => x.VeicoloId,
            //            principalTable: "Veicolo",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Noleggi_ClienteId",
            //    table: "Noleggi",
            //    column: "ClienteId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Noleggi_VeicoloId",
            //    table: "Noleggi",
            //    column: "VeicoloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Noleggi");

            //migrationBuilder.DropTable(
            //    name: "Clienti");

            //migrationBuilder.DropTable(
            //    name: "Veicolo");
        }
    }
}
