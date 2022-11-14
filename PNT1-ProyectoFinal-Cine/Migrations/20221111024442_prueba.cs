using Microsoft.EntityFrameworkCore.Migrations;

namespace PNT1_ProyectoFinal_Cine.Migrations
{
    public partial class prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Peliculas_PeliculaId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UsuarioId",
                table: "Ticket",
                newName: "IX_Ticket_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PeliculaId",
                table: "Ticket",
                newName: "IX_Ticket_PeliculaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Peliculas_PeliculaId",
                table: "Ticket",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "PeliculaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Usuarios_UsuarioId",
                table: "Ticket",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Peliculas_PeliculaId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Usuarios_UsuarioId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UsuarioId",
                table: "Tickets",
                newName: "IX_Tickets_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_PeliculaId",
                table: "Tickets",
                newName: "IX_Tickets_PeliculaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Peliculas_PeliculaId",
                table: "Tickets",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "PeliculaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioId",
                table: "Tickets",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
