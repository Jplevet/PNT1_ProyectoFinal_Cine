using Microsoft.EntityFrameworkCore.Migrations;

namespace PNT1_ProyectoFinal_Cine.Migrations
{
    public partial class agregueIdUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_usuarioNombreUsuario",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_usuarioNombreUsuario",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "usuarioNombreUsuario",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_usuarioId",
                table: "Tickets",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_usuarioId",
                table: "Tickets",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_usuarioId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_usuarioId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioNombreUsuario",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "NombreUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_usuarioNombreUsuario",
                table: "Tickets",
                column: "usuarioNombreUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_usuarioNombreUsuario",
                table: "Tickets",
                column: "usuarioNombreUsuario",
                principalTable: "Usuarios",
                principalColumn: "NombreUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
