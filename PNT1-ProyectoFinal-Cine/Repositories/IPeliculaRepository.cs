﻿using PNT1_ProyectoFinal_Cine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1_ProyectoFinal_Cine.Repositories
{
    public interface IPeliculaRepository
    {
        IEnumerable<Pelicula> GetPeliculas();
        Ticket GetPeliculaById(int id);
        void CreatePelicula(Pelicula cupcake);
        void DeletePelicula(int id);
        void SaveChanges();
        IQueryable<Pelicula> PopulatePeliculasDropDownList();
    }
}
