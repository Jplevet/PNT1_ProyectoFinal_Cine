using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre Usuario")]
        [Required(ErrorMessage = "Ingresar nombre válido")]        
        public string NombreUsuario { get; set; }
        
        
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Ingresar contraseña válida")]
        public string Contrasenia { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingresar nombre válido")]
        public string Nombre { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Ingresar mail válido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Ingresar email válido")]
        public string Mail { get; set; }
    }
}
