using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }


        [Range(1, 40)]
        [Display(Name = "Asiento")]
        [Required(ErrorMessage = "Ingresar asiento válido")]
        public int asiento { get; set; }

        public DateTime fecha { get; set; }

        [Display(Name = "Película")]
        [Required(ErrorMessage = "Ingresar película válida")]


        public virtual ICollection<Pelicula> Peliculas { get; set; }

        public Pelicula pelicula { get; set; }


        public Usuario usuario { get; set; }


        public Sala sala { get; set; }
    }
}
