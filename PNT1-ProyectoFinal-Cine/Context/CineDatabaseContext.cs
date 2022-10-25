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
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}