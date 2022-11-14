﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PNT1_ProyectoFinal_Cine.Context;

namespace PNT1_ProyectoFinal_Cine.Migrations
{
    [DbContext(typeof(CineDatabaseContext))]
    partial class CineDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PNT1_ProyectoFinal_Cine.Models.Pelicula", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PhotoPelicula")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeliculaId");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            PeliculaId = 1,
                            ImageMimeType = "image/jpeg",
                            ImageName = "Drive.jpg",
                            Titulo = "Drive"
                        },
                        new
                        {
                            PeliculaId = 2,
                            ImageMimeType = "image/jpeg",
                            ImageName = "Brothers.jpg",
                            Titulo = "Brother"
                        },
                        new
                        {
                            PeliculaId = 3,
                            ImageMimeType = "image/jpeg",
                            ImageName = "AmericanPsycho.jpg",
                            Titulo = "American Psycho"
                        },
                        new
                        {
                            PeliculaId = 4,
                            ImageMimeType = "image/jpeg",
                            ImageName = "shreck.jpg",
                            Titulo = "Shreck"
                        });
                });

            modelBuilder.Entity("PNT1_ProyectoFinal_Cine.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PeliculaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("asiento")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("sala")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("PNT1_ProyectoFinal_Cine.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PNT1_ProyectoFinal_Cine.Models.Ticket", b =>
                {
                    b.HasOne("PNT1_ProyectoFinal_Cine.Models.Pelicula", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNT1_ProyectoFinal_Cine.Models.Usuario", "usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
