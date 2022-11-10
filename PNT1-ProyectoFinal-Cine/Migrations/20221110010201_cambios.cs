using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PNT1_ProyectoFinal_Cine.Migrations
{
    public partial class cambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Peliculas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Peliculas",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoFile",
                table: "Peliculas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "PhotoFile",
                table: "Peliculas");
        }
    }
}
