using System.ComponentModel.DataAnnotations;

namespace simple_crud.Models
{
    public class EstudianteRequest
    {
        [Required]
        public string nombreEstudiante { get; set; }
        [Required]
        public int numDoc { get; set; }
        [Required]
        public string apellidos { get; set; }

        [Required]
        public int colegioId { get; set; }

        public bool estado { get; set; }

    }
}
