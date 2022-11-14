using Microsoft.AspNetCore.Http;
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


        [NotMapped]
        [Display(Name = "Cupcake Picture:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

    }
}
