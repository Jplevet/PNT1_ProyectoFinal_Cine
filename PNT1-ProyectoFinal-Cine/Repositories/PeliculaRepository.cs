using PNT1_ProyectoFinal_Cine.Context;
using PNT1_ProyectoFinal_Cine.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace PNT1_ProyectoFinal_Cine.Repositories
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
            return _context.Peliculas.Include(b => b.PeliculaId)
                .SingleOrDefault(c => c.PeliculaId == id);
        }


        //public void CreateCupcake(Cupcake cupcake)
        //{
        //    if (cupcake.PhotoAvatar != null && cupcake.PhotoAvatar.Length > 0)
        //    {
        //        cupcake.ImageMimeType = cupcake.PhotoAvatar.ContentType;
        //        cupcake.ImageName = Path.GetFileName(cupcake.PhotoAvatar.FileName);
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            cupcake.PhotoAvatar.CopyTo(memoryStream);
        //            cupcake.PhotoFile = memoryStream.ToArray();
        //        }
        //        _context.Add(cupcake);
        //        _context.SaveChanges();
        //    }
        //}

        //public void DeleteCupcake(int id)
        //{
        //    var cupcake = _context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id);
        //    _context.Cupcakes.Remove(cupcake);
        //    _context.SaveChanges();
        //}
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        //public IQueryable<Bakery> PopulateBakeriesDropDownList()
        //{
        //    var bakeriesQuery = from b in _context.Bakeries
        //                        orderby b.BakeryName
        //                        select b;
        //    return bakeriesQuery;
        //}

        public void CreatePelicula(Pelicula pelicula)
        {
            if (pelicula.PhotoAvatar != null && pelicula.PhotoAvatar.Length > 0)
            {
                pelicula.ImageMimeType = pelicula.PhotoAvatar.ContentType;
                pelicula.ImageName = Path.GetFileName(pelicula.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    pelicula.PhotoAvatar.CopyTo(memoryStream);
                    pelicula.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(pelicula);
                _context.SaveChanges();
            }
        }

        public void DeletePelicula(int id)
        {
            var pelicula = _context.Peliculas.SingleOrDefault(c => c.PeliculaId == id);
            _context.Peliculas.Remove(pelicula);
            _context.SaveChanges();
        }

        public IQueryable<Pelicula> PopulatePeliculasDropDownList()
        {
            var peliculasQuery = from b in _context.Peliculas
                                orderby b.titulo
                                select b;
            return peliculasQuery;
        }
    }
}

