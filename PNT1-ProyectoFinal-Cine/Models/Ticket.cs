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

        public int TicketId { get; set; }


        [Range(1, 40)]
        [Display(Name = "Asiento")]
        [Required(ErrorMessage = "Ingresar asiento válido")]
        public int asiento { get; set; }

        public DateTime fecha { get; set; }

        [Display(Name = "Película")]
        [Required(ErrorMessage = "Ingresar película válida")]


        public int? PeliculaId { get; set; }
        public virtual Pelicula Pelicula { get; set; }


        public int? UsuarioId { get; set; }
        public virtual Usuario usuario { get; set; }


        public Sala sala { get; set; }

        //public int? BakeryId { get; set; }
        //public virtual Bakery Bakery { get; set; }

    }
}
