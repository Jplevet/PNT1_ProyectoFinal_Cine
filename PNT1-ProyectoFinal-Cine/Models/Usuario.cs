using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string NombreUsuario { get; set; }
        public string Contrasenia{ get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
    }
}
