using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public enum Sala
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //public int Id { get; set; }
        //public int cantAsientos { get; set; }
        //public Pelicula peliculaAsignada { get; set; }

        Sala1,Sala2,Sala3
    }
}
