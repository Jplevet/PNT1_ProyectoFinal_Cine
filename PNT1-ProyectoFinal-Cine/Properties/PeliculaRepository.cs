using PNT1_ProyectoFinal_Cine.Data;
using PNT1_ProyectoFinal_Cine.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PNT1_ProyectoFinal_Cine.Properties
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private PeliculaContext _context;

        public PeliculaRepository(PeliculaContext context)
        {
            _context = context;
        }
        public IEnumerable<Pelicula> GetPeliculas()
        {
            return _context.peliculas.ToList();
        }


        public Pelicula GetPeliculaById(int id)
        {
            return _context.peliculas.Include(b => b.pelicula)
                .SingleOrDefault(c => c.PeliculaId == id);
        }


        public void CreatePelicula(Pelicula pelicula)
        {
            if (pelicula.titulo != null && pelicula.titulo.Length > 0)
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
            var cupcake = _context.peliculas.SingleOrDefault(c => c.PeliculaId == id);
            _context.peliculas.Remove(cupcake);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<Pelicula> PopulatePeliculasDropDownList()
        {
            var bakeriesQuery = from b in _context.peliculas
                                orderby b.titulo
                                select b;
            return bakeriesQuery;
        }
    }

}
