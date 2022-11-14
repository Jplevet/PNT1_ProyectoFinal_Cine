using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Pelicula
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PeliculaId { get; set; }
        [Required(ErrorMessage = "Seleccionar Película correcta")]
        public string Titulo { get; set; }
        public string ImageMimeType { get; set; }
        public byte[] PhotoPelicula { get; set; }
        [NotMapped]
        [Display(Name = "Pelicula imagen:")]
        public IFormFile PhotoAvaImg { get; set; }
        public string ImageName { get; set; }
    }
}
