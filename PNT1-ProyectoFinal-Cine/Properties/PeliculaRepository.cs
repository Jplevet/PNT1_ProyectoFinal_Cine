using PNT1_ProyectoFinal_Cine.Context;
using PNT1_ProyectoFinal_Cine.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PNT1_ProyectoFinal_Cine.Properties
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private CineDatabaseContext _context;

        public PeliculaRepository(CineDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Pelicula> GetPeliculas()
        {
            return _context.Peliculas.ToList();
        }


        public Pelicula GetPeliculaById(int id)
        {
            return _context.Peliculas.Include(b => b.Titulo)
                .SingleOrDefault(c => c.PeliculaId == id);
        }


        public void CreatePelicula(Pelicula pelicula)
        {
            if (pelicula.Titulo != null && pelicula.Titulo.Length > 0)
            {
                pelicula.ImageMimeType = pelicula.PhotoAvaImg.ContentType;
                pelicula.ImageName = Path.GetFileName(pelicula.PhotoAvaImg.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    pelicula.PhotoAvaImg.CopyTo(memoryStream);
                    pelicula.PhotoPelicula = memoryStream.ToArray();
                }
                _context.Add(pelicula);
                _context.SaveChanges();
            }
        }

        public void DeletePelicula(int id)
        {
            var cupcake = _context.Peliculas.SingleOrDefault(c => c.PeliculaId == id);
            _context.Peliculas.Remove(cupcake);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<Pelicula> PopulatePeliculasDropDownList()
        {
            var bakeriesQuery = from b in _context.Peliculas
                                orderby b.Titulo
                                select b;
            return bakeriesQuery;
        }
    }

}
