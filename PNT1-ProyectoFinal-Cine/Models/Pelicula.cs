using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PeliculaId { get; set; }
        public string titulo { get; set; }


        [Required(ErrorMessage = "Please select a bakery")]
        public int? Id { get; set; }

        public virtual Pelicula pelicula { get; set; }

    }
}
