using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using PNT1_ProyectoFinal_Cine.Models;

namespace PNT1_ProyectoFinal_Cine.Properties
{
    public interface IPeliculaRepository
    {
        IEnumerable<Pelicula> GetPeliculas();
        Pelicula GetPeliculaById(int id);
        void CreatePelicula(Pelicula cupcake);
        void DeletePelicula(int id);
        void SaveChanges();
        IQueryable<Pelicula> PopulatePeliculasDropDownList();
    }
}
