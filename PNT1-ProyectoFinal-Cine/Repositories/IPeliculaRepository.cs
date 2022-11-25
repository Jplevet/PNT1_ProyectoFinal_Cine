using PNT1_ProyectoFinal_Cine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1_ProyectoFinal_Cine.Repositories
{
    public interface IPeliculaRepository
    {
        IEnumerable<Pelicula> GetPeliculas();
        Pelicula GetPeliculaById(int id);
        void CreatePelicula(Pelicula pelicula);
        void DeletePelicula(int id);
        void SaveChanges();
        IQueryable<Pelicula> PopulatePeliculasDropDownList();
    }
}
