using Microsoft.EntityFrameworkCore.Migrations;

namespace PNT1_ProyectoFinal_Cine.Migrations
{
    public partial class cambiosEnClaseTicketv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Peliculas_peliculaAsignadaId",
                table: "Salas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Peliculas_peliculaId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Salas_peliculaAsignadaId",
                table: "Salas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "peliculaAsignadaId",
                table: "Salas");

            migrationBuilder.RenameColumn(
                name: "peliculaId",
                table: "Tickets",
                newName: "PeliculaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_peliculaId",
                table: "Tickets",
                newName: "IX_Tickets_PeliculaId");

            migrationBuilder.AddColumn<int>(
                name: "peliculaAsignadaPeliculaId",
                table: "Salas",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Peliculas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PeliculaId",
                table: "Peliculas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PeliculaId1",
                table: "Peliculas",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_peliculaAsignadaPeliculaId",
                table: "Salas",
                column: "peliculaAsignadaPeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_PeliculaId1",
                table: "Peliculas",
                column: "PeliculaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Peliculas_PeliculaId1",
                table: "Peliculas",
                column: "PeliculaId1",
                principalTable: "Peliculas",
                principalColumn: "PeliculaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Peliculas_peliculaAsignadaPeliculaId",
                table: "Salas",
                column: "peliculaAsignadaPeliculaId",
                principalTable: "Peliculas",
                principalColumn: "PeliculaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Peliculas_PeliculaId",
                table: "Tickets",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "PeliculaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Peliculas_PeliculaId1",
                table: "Peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Peliculas_peliculaAsignadaPeliculaId",
                table: "Salas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Peliculas_PeliculaId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Salas_peliculaAsignadaPeliculaId",
                table: "Salas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_PeliculaId1",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "peliculaAsignadaPeliculaId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "PeliculaId1",
                table: "Peliculas");

            migrationBuilder.RenameColumn(
                name: "PeliculaId",
                table: "Tickets",
                newName: "peliculaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PeliculaId",
                table: "Tickets",
                newName: "IX_Tickets_peliculaId");

            migrationBuilder.AddColumn<int>(
                name: "peliculaAsignadaId",
                table: "Salas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Peliculas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_peliculaAsignadaId",
                table: "Salas",
                column: "peliculaAsignadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Peliculas_peliculaAsignadaId",
                table: "Salas",
                column: "peliculaAsignadaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Peliculas_peliculaId",
                table: "Tickets",
                column: "peliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
