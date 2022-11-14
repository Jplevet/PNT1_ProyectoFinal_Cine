using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PNT1_ProyectoFinal_Cine.Models;

namespace PNT1_ProyectoFinal_Cine.Context
{
    public class CineDatabaseContext : DbContext
    {
        public CineDatabaseContext(DbContextOptions<CineDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Pelicula>().HasData(
              new Pelicula
              {
                  PeliculaId = 1,
                  Titulo = "Drive",
                  ImageMimeType = "image/jpeg",
                  ImageName = "Drive.jpg"
              },
              new Pelicula
              {
                  PeliculaId = 2,
                  Titulo = "Brother",
                  ImageMimeType = "image/jpeg",
                  ImageName = "Brothers.jpg"
              },
              new Pelicula
              {
                  PeliculaId = 3,
                  Titulo = "American Psycho",
                  ImageMimeType = "image/jpeg",
                  ImageName = "AmericanPsycho.jpg"
              },
              new Pelicula
              {
                  PeliculaId = 4,
                  Titulo = "Shreck",
                  ImageMimeType = "image/jpeg",
                  ImageName = "shreck.jpg"
              }
          );
        }
    }
}
