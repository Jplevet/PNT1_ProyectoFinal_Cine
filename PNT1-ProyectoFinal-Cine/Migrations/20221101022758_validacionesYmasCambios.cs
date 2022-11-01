using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PNT1_ProyectoFinal_Cine.Migrations
{
    public partial class validacionesYmasCambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Peliculas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_TicketId",
                table: "Peliculas",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Tickets_TicketId",
                table: "Peliculas",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Tickets_TicketId",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_TicketId",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "fecha",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Peliculas");
        }
    }
}
