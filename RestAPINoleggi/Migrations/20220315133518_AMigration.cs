using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPINoleggi.Migrations
{
    public partial class AMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noleggi_Clienti_ClienteId",
                table: "Noleggi");

            migrationBuilder.DropForeignKey(
                name: "FK_Noleggi_Veicolo_VeicoloId",
                table: "Noleggi");

            migrationBuilder.AlterColumn<int>(
                name: "VeicoloId",
                table: "Noleggi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Noleggi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Noleggi_Clienti_ClienteId",
                table: "Noleggi",
                column: "ClienteId",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Noleggi_Veicolo_VeicoloId",
                table: "Noleggi",
                column: "VeicoloId",
                principalTable: "Veicolo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noleggi_Clienti_ClienteId",
                table: "Noleggi");

            migrationBuilder.DropForeignKey(
                name: "FK_Noleggi_Veicolo_VeicoloId",
                table: "Noleggi");

            migrationBuilder.AlterColumn<int>(
                name: "VeicoloId",
                table: "Noleggi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Noleggi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Noleggi_Clienti_ClienteId",
                table: "Noleggi",
                column: "ClienteId",
                principalTable: "Clienti",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Noleggi_Veicolo_VeicoloId",
                table: "Noleggi",
                column: "VeicoloId",
                principalTable: "Veicolo",
                principalColumn: "Id");
        }
    }
}
