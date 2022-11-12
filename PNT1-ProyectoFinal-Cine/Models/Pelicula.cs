using Microsoft.AspNetCore.Http;
using PNT1_ProyectoFinal_Cine.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PNT1_ProyectoFinal_Cine.Models
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PeliculaId { get; set; }
        [Required(ErrorMessage = "Seleccionar Película correcta")]
        public string titulo { get; set; }
        public string ImageMimeType { get; set; }
        public byte[] PhotoPelicula { get; set; }
        public IFormFile PhotoAvaImg { get; set; }
        public string ImageName { get; set; }
        public virtual Pelicula pelicula { get; set; }
    }
}
