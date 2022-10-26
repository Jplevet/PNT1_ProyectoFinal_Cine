using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        
        [Display(Name = "Asiento")]
        [Required(ErrorMessage = "Ingresar asiento válido")]
        public int asiento { get; set; }
        public Pelicula pelicula { get; set; }
        public Usuario usuario { get; set; }
        public Sala sala { get; set; }
    }
}
