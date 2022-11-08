using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PeliculaId { get; set; }


        [Required(ErrorMessage = "Seleccionar Película correcta")]
        public string titulo { get; set; }

    }
}
