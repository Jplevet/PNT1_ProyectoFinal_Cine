using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PNT1_ProyectoFinal_Cine.Models;
namespace PNT1_ProyectoFinal_Cine.Data
{
    public class PeliculaContext: DbContext
    {
        public PeliculaContext(DbContextOptions<PeliculaContext> options)
       : base(options)
        {
        }

        public DbSet<Pelicula> peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>().HasData(
               new Pelicula
               {
                   PeliculaId = 1,
                   titulo = "Drive"

               },
                new Pelicula
                {
                    PeliculaId = 1,
                    titulo = "Brothers"
                },
                new Pelicula
                {
                    PeliculaId = 1,
                    titulo = "American Psycho"
                },
                new Pelicula
                {
                    PeliculaId = 1,
                    titulo = "Shreck"
                }
            ) ;

            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula
                {
                    PeliculaId = 1,
                    titulo = "Drive",
                    ImageMimeType = "image/jpeg",
                    ImageName = "Drive.jpg"
                },
                new Pelicula
                {
                    PeliculaId = 2,
                    titulo = "Brother",
                    ImageMimeType = "image/jpeg",
                    ImageName = "Brothers.jpg"
                },
                new Pelicula
                {
                    PeliculaId = 3,
                    titulo = "American Psycho",
                    ImageMimeType = "image/jpeg",
                    ImageName = "AmericanPsycho.jpg"
                },
                new Pelicula
                {
                    PeliculaId = 2,
                    titulo = "Shreck",
                    ImageMimeType = "image/jpeg",
                    ImageName = "shreck.jpg"
                }
            );
        }
    }
}
